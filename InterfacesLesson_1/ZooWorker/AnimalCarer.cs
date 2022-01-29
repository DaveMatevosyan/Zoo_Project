namespace Zoo_Project.ZooWorker
{
    public class AnimalCarer : ZooWorker
    {
        public AnimalCarer(string name, int ID, double salary) : base(name, ID, salary)
        {

        }
        public void AddFoodToCage(Zoo zoo, int cageID)
        {
            try
            {
                if (IsFoodsStorageEmpty(zoo.FoodsStorage))
                {
                    throw new Exception("No food available.");
                }
                else
                {
                    foreach (IFood food in zoo.FoodsStorage)
                    {
                        if (food.GetType() == zoo.ZooCages[cageID].CageAnimal.FirstOrDefault().Foods.FirstOrDefault().GetType())
                        {
                            zoo.ZooCages[cageID].CageDoorState = DoorState.Open;
                            zoo.ZooCages[cageID].AvailableFood.Add(food);
                            zoo.ZooCages[cageID].CageDoorState = DoorState.Close;
                            zoo.FoodsStorage.Remove(food);
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
        //private List<Cage>? FoodMissingCages(Zoo zoo)
        //{
        //    List<Cage>? cages = null;
        //    foreach (var cage in zoo.ZooCages)
        //    {
        //        if (cage.Value.AvailableFood.Count < 2)
        //        {
        //            cages.Add(cage.Value);
        //        }
        //    }
        //    return cages;
        //}
        private bool IsFoodsStorageEmpty(List<IFood> foods) => foods.Count == 0;
    }
}
