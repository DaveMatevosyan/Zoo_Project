using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public class Snake : Animal, ICrawling
    {
        public override List<IFood> Foods { get; set; } = new List<IFood>() { new Meat() };
        public Snake(string name, GenderType gender)
        {
            this.Name = name;
            this.Gender = gender;
        }
        public void Crawl()
        {
            Console.WriteLine("Snake crawl");
        }
        public override void Sound()
        {
            Console.WriteLine("Snake sound");
        }
    }
}
