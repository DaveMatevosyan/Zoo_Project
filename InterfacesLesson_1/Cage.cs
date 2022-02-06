namespace Zoo_Project
{
    public enum DoorState
    {
        Open = 0,
        Close = 1
    }

    public class Cage
    {
        public int CageID { get; set; }
        public double CageArea { get; set; }
        public List<Animal> CageAnimal { get; set; } = new(2);
        public List<IFood> AvailableFood { get; set; } = new(2);
        public DoorState CageDoorState { get; set; }
        public Cage()
        {
            this.CageID = -1;
            this.CageArea = -1;
            this.CageDoorState = DoorState.Close;
        }
        public Cage(int CageID, double CageArea, DoorState CageDoorState)
        {
            this.CageID = CageID;
            this.CageArea = CageArea;
            this.CageDoorState = CageDoorState;
        }
        
    }
}
