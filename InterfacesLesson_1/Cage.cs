using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Project
{
    public enum DoorState
    {
        Open = 0,
        Close = 1
    }

    public class Cage
    {
        public int CageNumber { get; set; }
        public double CageArea { get; set; }
        public List<Animal> CageAnimal { get; set; } = new();
        public DoorState CageDoorState { get; set; }
        public Cage()
        {
            this.CageNumber = -1;
            this.CageArea = -1;
            this.CageDoorState = DoorState.Close;
        }
        public Cage(int CageNumber, double CageArea, DoorState CageDoorState)
        {
            this.CageNumber = CageNumber;
            this.CageArea = CageArea;
            this.CageDoorState = CageDoorState;
        }
    }
}
