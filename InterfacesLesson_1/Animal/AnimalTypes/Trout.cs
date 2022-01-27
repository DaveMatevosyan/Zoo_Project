using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public class Trout : Animal, ISwimmable
    {
        public override List<IFood> Foods { get; set; } = new List<IFood>() { new Grass() };
        public Trout(string name, GenderType gender)
        {
            this.Name = name;
            this.Gender = gender;
        }
        public override void Sound()
        {
            Console.WriteLine("Trout sound.");
        }
        public void Swim()
        {
            Console.WriteLine("Trout swim.");
        }
    }
}
