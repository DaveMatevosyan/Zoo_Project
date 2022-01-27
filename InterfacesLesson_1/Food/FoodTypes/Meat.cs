using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public class Meat : IFood
    {
        public int Calories { get; set; } = 0;
        public string Name { get; set; }
        public Meat()
        {
            this.Name = "Meat";
            this.Calories = 0;
        }
        public Meat(int calories, string name)
        {
            this.Calories = calories;
            this.Name = name;
        }
    }
}
