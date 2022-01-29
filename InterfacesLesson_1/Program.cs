using Zoo_Project;

//Lion lion = new Lion("Simba", GenderType.Male);
//try
//{
//    lion.Stomach.SetStomachProperties(50, 100, 20);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message + ex.StackTrace);
//}
//Lion lion1 = new Lion("Simba2", GenderType.Male);
//lion1.IsAlive = false;
//lion1.Feed(new Meat());
//GC.Collect();
while (true)
{
    Zoo myZoo = new Zoo();
    myZoo.CageGenerator(2);
    foreach (var item in myZoo.ZooCages)
    {
        Console.WriteLine(item.Key);
    }
    myZoo.AddAnimalToZoo(new Lion("Simba", GenderType.Male));
    //myZoo.ZooAnimals.First().Value.ID = 1;
    //myZoo.ZooAnimals.First().Value.CageID = myZoo.ZooCages.First().Key;
    
    Console.ReadLine();

}



Console.ReadLine();




