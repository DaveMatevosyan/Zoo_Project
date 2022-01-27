using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public static class CageExtension
    {
        public static void AddAnimalToCage(this Cage cage, Animal animal)
        {
            try
            {
                if (cage.CageAnimal.Count >= 2)
                {
                    throw new Exception("No enough space.");
                }
                else
                {
                    cage.CageDoorState = DoorState.Open;
                    try
                    {
                        cage.CageAnimal.Add(animal);
                    }
                    catch (Exception ex)
                    {
                        //Log exception
                        Console.WriteLine("Unable to add animal to cage.\n" + ex.Message);
                    }
                    finally
                    {
                        cage.CageDoorState = DoorState.Close;
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeleteAnimalFromCage(this Cage cage, Animal animal)
        {
            try
            {
                cage.CageAnimal.Remove(animal);
            }
            catch (Exception ex)
            {
                //Log exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}
