using System.Timers;

namespace Zoo_Project
{
    public class Zoo
    {
        private static System.Timers.Timer ZooTimer { get; set; } = new System.Timers.Timer();
        public Dictionary<int, Cage> ZooCages { get; private set; }
        public Dictionary<int, ZooWorker.ZooWorker> ZooWorkers { get; private set; }
        public List<IFood> FoodsStorage { get; set; }
        public Dictionary<int, Animal> ZooAnimals { get; private set; }
        public Zoo()
        {
            ZooTimer.Elapsed += IsAliveCheker;
            ZooTimer.Elapsed += GettingHungry;
            ZooTimer.Enabled = true;
            ZooTimer.AutoReset = true;
            this.ZooCages = new();
            this.FoodsStorage = new();
            this.ZooAnimals = new();
        }
        public Zoo(params Cage[] ZooCages) : base()
        {
            //TODO 
            if (ZooCages == null)
            {
                //TODO: Exception-ներում մեսիջներ գրի, որ հետո հեշտ գտնես
                throw new NullReferenceException("ZooCages is null");
            }
            foreach (var cage in ZooCages)
            {
                try
                {
                    //TODO Ամեն անգամ նույն ստուգումն անում ես ցիկլի ներսում
                    //if (ZooCages != null)
                    //{
                    this.ZooCages.Add(cage.CageID, cage);
                    //}
                    //else
                    //{
                    //    //TODO: Exception-ներում մեսիջներ գրի, որ հետո հեշտ գտնես
                    //throw new NullReferenceException("ZooCages is null");
                    //  }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Log exception
                }
            }
        }
        //TODO: ZOO-ն չպետքա կենդանուն սովածացնի, սա պետք ա լինի կենդանու ներսում։
        public void GettingHungry(Object source, ElapsedEventArgs e)
        {
            try
            {
                foreach (var animal in ZooAnimals.Values)
                {
                    animal.GettingHungry();
                    Console.WriteLine(animal.Stomach.StomatchFullness + " stomatch fullness.");
                    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //TODO սա նույնպես կարա լինի կենդանու ներսում
        private void IsAliveCheker(Object source, ElapsedEventArgs e)
        {
            foreach (Animal animal in ZooAnimals.Values)
            {
                if (animal.Stomach.StomatchFullness == 0 && animal.IsAlive)
                {
                    animal.DeathDate = DateTime.Now;
                    animal.IsAlive = false;
                    RemoveAnimalFromZoo(animal.ID);
                    Console.WriteLine(animal.Name + " is dead. Death time is - " + animal.DeathDate + ". Age - " + (animal.DeathDate - animal.BirthDate));
                }
            }
        }
        private void RemoveAnimalFromZoo(int AnimalID)
        {
            ZooCages[ZooAnimals[AnimalID].CageID].DeleteAnimalFromCage(ZooAnimals[AnimalID]);
            this.ZooAnimals.Remove(AnimalID);
        }
        public void AddAnimalToZoo(Animal animal)
        {
            try
            {
                int? cageID = FreeCages().First();
                if (cageID != null)
                {
                    animal.CageID = (int)cageID;
                    ZooCages[(int)cageID].CageAnimal.Add(animal);
                    ZooAnimals.Add(animal.ID, animal);
                }
                else
                {
                    throw new Exception("No free cages.");
                }
            }
            catch (Exception ex)
            {
                //Log exception
                Console.WriteLine(ex.Message);
            }
        }
        private List<int>? FreeCages()
        {
            List<int>? freeCages = new List<int>();
            foreach (Cage cage in ZooCages.Values)
            {
                if (cage.CageAnimal.Count < 2)
                {
                    freeCages.Add(cage.CageID);
                }
            }
            return freeCages;
        }
    }
}
