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
        public int ID { get; set; }
        public int CageNumber { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; } = GenderType.Male;
        public DateTime BirthDate { get; set; }
        public Stomach Stomach { get; set; } = new Stomach();
        public bool IsAlive { get; set; } = true;
        public DateTime DeathDate { get; set; }
        public abstract List<IFood> Foods { get; set; }
        public Animal()
        {

        }
        public override string ToString()
        {
            return "Name: " + Name + ", Gender: " + Gender.ToString();
        }
        public abstract void Sound();
        public virtual void Feed(IFood food)
        {
            if (CanEat(food) && this.IsHungry() && this.IsAlive)
            {
                Console.WriteLine(this.Name + " eats " + food.GetType().Name + ".");
                this.Stomach.StomatchFullness += 20;
            }
            else if (CanEat(food) && !this.IsHungry())
            {
                Console.WriteLine(this.Name + " can eat " + food.GetType().Name + " but it's not hungry enough. Please wait a little bit.");
            }
            else
            {
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
        public bool IsHungry()
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
        public virtual void GettingHungry()
        {
            try
            {
                this.Stomach.StomatchFullness--;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void InformIfIsHungry()
        {
            if (IsHungry())
            {
                this.Sound();
            }
        }
        public void FeedTimer()
        {
            foreach (var item in Foods)
            {
                try
                {
                    Feed(item);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
