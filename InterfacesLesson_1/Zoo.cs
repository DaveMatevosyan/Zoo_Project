using Zoo_Project.ZooWorker;

namespace Zoo_Project
{
    public class Zoo
    {
        private static System.Timers.Timer ZooTimer { get; set; } = new System.Timers.Timer();
        public Dictionary<int, Cage> ZooCages { get; private set; }
        public Dictionary<int, ZooWorker.ZooWorker> ZooWorkers { get; private set; }
        public List<IFood> FoodsStorage { get; set; } = new List<IFood> { new Meat(), new Meat(), new Meat(), new Meat(), new Meat(), new Meat(), new Meat() };
        public Dictionary<int, Animal> ZooAnimals { get; private set; }
        public Action<string> AnimalFeeded { get; set; }
        public Zoo()
        {
            ZooTimer.Enabled = true;
            ZooTimer.AutoReset = true;
            this.ZooCages = new();
            //this.FoodsStorage = new();
            this.ZooAnimals = new();
            this.ZooWorkers = new();
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
                    this.ZooCages.Add(cage.CageID, cage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Log exception
                }
            }
        }
        public void RemoveAnimalFromZoo(int AnimalID)
        {
            ZooCages[ZooAnimals[AnimalID].AnimalsCage.CageID].DeleteAnimalFromCage(ZooAnimals[AnimalID]);
            this.ZooAnimals.Remove(AnimalID);
        }
        public void AddAnimalToZoo(Animal animal)
        {
            try
            {
                int? cageID = FreeCages().First();
                if (cageID != null)
                {
                    animal.AnimalsCage = ZooCages[(int)cageID];
                    ZooCages[(int)cageID].CageAnimal.Add(animal);
                    ZooAnimals.Add(animal.ID, animal);
                    animal.AnimalsZoo = this;
                    AnimalCarer animalCarer = (AnimalCarer)ZooWorkers.FirstOrDefault().Value;
                    if (animalCarer != null)
                    {
                        animal.CageFoodAdding += animalCarer.AddFoodToCage;
                    }
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
        public void AddWorkerToZoo()
        {
            AnimalCarer animalCarer = new AnimalCarer("Steve", 1, 100);
            animalCarer.WorkersZoo = this;
            ZooWorkers.Add(animalCarer.ID, animalCarer);
        }
        private List<int>? FreeCages()
        {
            List<int>? freeCages = new();
            foreach (Cage cage in ZooCages.Values)
            {
                if (cage.CageAnimal.Count < 2)
                {
                    freeCages.Add(cage.CageID);
                }
            }
            return freeCages;
        }
        public void DisplayActionInformation(string str)
        {
            Console.WriteLine(str);
        }
    }
}
