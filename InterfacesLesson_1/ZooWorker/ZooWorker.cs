using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project.ZooWorker
{
    public abstract class ZooWorker
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Salary { get; set; }
        public Zoo WorkersZoo { get; set; }
        public ZooWorker(string name, int ID, double Salary)
        {
            this.Name = name;
            this.Salary = Salary;
            this.ID = ID;
        }
    }
}
