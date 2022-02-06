using System.Timers;

public enum GenderType
{
    Male = 1,
    Female = 2
}

namespace Zoo_Project
{

    public abstract class Animal
    {
        public event Action<IFood> AnimalIsHungry;
        public event Action<int> CageFoodAdding;
        private static System.Timers.Timer AnimalTimer { get; set; } = new System.Timers.Timer();
        public int ID { get; set; }
        public Cage AnimalsCage { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; } = GenderType.Male;
        public DateTime BirthDate { get; set; }
        public Stomach Stomach { get; set; } = new Stomach();
        public bool IsAlive { get; set; } = true;
        public DateTime DeathDate { get; set; }
        public abstract List<IFood> Foods { get; set; }
        public Zoo AnimalsZoo { get; set; }
        public Animal()
        {
            AnimalIsHungry = this.Feed;
            AnimalTimer.Elapsed += GettingHungry;
            AnimalTimer.Elapsed += IsAliveCheker;
            AnimalTimer.Elapsed += IsHungry;
            AnimalTimer.Enabled = true;
            AnimalTimer.AutoReset = true;
            Random rand = new();
            ID = rand.Next(1, 1000);
        }


        public override string ToString()
        {
            return "Name: " + Name + ", Gender: " + Gender.ToString();
        }
        public abstract void Sound();
        public virtual void Feed(IFood food)
        {
            if (food == null)
            {
                Console.WriteLine("There is no food in the cage.");
                if (CageFoodAdding != null)
                {
                    CageFoodAdding(this.AnimalsCage.CageID);
                }
            }
            else if (CanEat(food) && this.IsHungryChecker() && this.IsAlive)
            {

                //Action<string> AnimalEat = new Action<string>(this.Name + " eats " + food.GetType().Name + ".");
                Console.WriteLine(this.Name + " eats " + food.GetType().Name + ".");
                this.Stomach.StomatchFullness += 20;
                RemoveFoodFromCage(food);
            }
            else if (CanEat(food) && !this.IsHungryChecker())
            {
                //AnimalEat(this.Name + " can eat " + food.GetType().Name + " but it's not hungry enough. Please wait a little bit.");
                Console.WriteLine(this.Name + " can eat " + food.GetType().Name + " but it's not hungry enough. Please wait a little bit.");
            }
            else
            {
                //AnimalEat(this.Name + " can't eat " + food.GetType().Name + ".");
                Console.WriteLine(this.Name + " can't eat " + food.GetType().Name + ".");
            }
        }
        public virtual bool CanEat(IFood food)
        {
            foreach (var f in this.Foods)
            {
                if (food.GetType() == f.GetType())
                {
                    return true;
                }
            }
            return false;
        }
        private void IsHungry(object? sender, ElapsedEventArgs e)
        {
            if (this.IsHungryChecker())
            {
                AnimalIsHungry(this.AnimalsCage.AvailableFood.FirstOrDefault());
            }
        }
        private bool IsHungryChecker()
        {
            if (this.Stomach.StomatchFullness <= this.Stomach.HungrinessCoefficient)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void GettingHungry(Object obj, ElapsedEventArgs e)
        {
            try
            {
                this.Stomach.StomatchFullness--;
                Console.WriteLine(Stomach.StomatchFullness + " stomatch fullness.");
                Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void IsAliveCheker(Object source, ElapsedEventArgs e)
        {
            if (Stomach.IsStomachEmpty() && IsAlive)
            {
                AnimalTimer.Elapsed -= GettingHungry;
                AnimalTimer.Elapsed -= IsHungry;
                DeathDate = DateTime.Now;
                IsAlive = false;
                AnimalsZoo.RemoveAnimalFromZoo(ID);
                Console.WriteLine(Name + " is dead. Death time is - " + DeathDate + ". Age - " + (DeathDate - BirthDate));
            }
        }
        private void RemoveFoodFromCage(IFood food)
        {
            this.AnimalsCage.AvailableFood.Remove(food);
        }
    }
}
