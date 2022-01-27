using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public class Grass : IFood
    {
        public int Calories { get; set; }
        public string Name { get; set; }
        public Grass()
        {
            this.Name = "Grass";
            this.Calories = 0;
        }
        public Grass(int calories, string name)
        {
            this.Name = name;
            this.Calories = calories;
        }
    }
}
