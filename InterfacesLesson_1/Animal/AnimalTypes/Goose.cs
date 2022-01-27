using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public class Goose : Animal,IWalkable,ISwimmable,IFlyable
    {
        public override List<IFood> Foods { get; set; } = new List<IFood>() { new Grass() };
        public void Fly()
        {
            Console.WriteLine("Goose fly.");
        }
        public override void Sound()
        {
            Console.WriteLine("Goose sound.");
        }
        public void Swim()
        {
            Console.WriteLine("Goose swim.");
        }
        public void Walk()
        {
            Console.WriteLine("Goose walk.");
        }
    }
}
