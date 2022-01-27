namespace Zoo_Project
{
    public static class ZooExtension
    {
        public static void CageGenerator(this Zoo myZoo, int CageGeneratorCount)
        {
            try
            {
                for (int i = 0; i < CageGeneratorCount; i++)
                {
                    (int CageNumber, double CageArea) CageParameters = CageParametersRandomGenerator();
                    Cage Cage = new Cage(CageParameters.CageNumber,CageParameters.CageArea,DoorState.Close);
                    try
                    {
                        myZoo.ZooCages.Add(Cage.CageNumber, Cage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        i--;
                        //Log exception
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Log exception
            }
        }
        private static (int, double) CageParametersRandomGenerator()
        {
            Random random = new Random();
            (int, double) CageParameters = (random.Next(1, 1000), random.NextDouble() * 100);
            return CageParameters;
        }
        
    }
}
