namespace Zoo_Project.ZooWorker
{
    public class AnimalCarer : ZooWorker
    {
        public AnimalCarer(string name, int ID, double salary) : base(name, ID, salary)
        {
            
        }
        public void AddFoodToCage(int cageID)
        {
            try
            {
                if (IsFoodsStorageEmpty(WorkersZoo.FoodsStorage))
                {
                    throw new Exception("No food available.");
                }
                else
                {
                    foreach (IFood food in WorkersZoo.FoodsStorage)
                    {
                        if (food.GetType() == WorkersZoo.ZooCages[cageID].CageAnimal.FirstOrDefault().Foods.FirstOrDefault().GetType())
                        {
                            WorkersZoo.ZooCages[cageID].CageDoorState = DoorState.Open;
                            WorkersZoo.ZooCages[cageID].AvailableFood.Add(food);
                            WorkersZoo.ZooCages[cageID].CageDoorState = DoorState.Close;
                            WorkersZoo.FoodsStorage.Remove(food);
                            Console.WriteLine(food.GetType + " added to the cage with number: " + cageID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception
                Console.WriteLine(ex.Message);
            }
        }
        public List<int>? CheckFoodsInCages(List<Cage> cages)
        {
            List<int>? cagesWithoutFoods = null;
            foreach (Cage cage in cages)
            {
                if (cage.AvailableFood.Count < 2)
                {
                    cagesWithoutFoods.Add(cage.CageID);
                }
            }
            return cagesWithoutFoods;
        }
        private bool IsFoodsStorageEmpty(List<IFood> foods) => foods.Count == 0;


    }
}
