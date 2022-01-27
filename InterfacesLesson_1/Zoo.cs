using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Zoo_Project.ZooWorker;

namespace Zoo_Project
{
    public class Zoo
    {
        private static System.Timers.Timer ZooTimer { get; set; } = new System.Timers.Timer();
        public Dictionary<int, Cage> ZooCages { get; private set; }
        public Dictionary<int,ZooWorker.ZooWorker> ZooWorkers { get; private set;}
        public List<IFood> FoodsStorage { get; set; }
        public Dictionary<int, Animal> ZooAnimals { get; set; }
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
                    //    this.ZooCages.Add(cage.CageNumber, cage);
                    //}
                    //else
                    //{
                    //    //TODO: Exception-ներում մեսիջներ գրի, որ հետո հեշտ գտնես
                        throw new NullReferenceException("ZooCages is null");
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
            this.ZooAnimals.Remove(AnimalID);
        }

    }
}
