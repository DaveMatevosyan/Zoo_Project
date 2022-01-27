namespace InterfacesLesson_1
{
    public class Stomach
    {
        private int hungrinessCoefficient = 50;
        private int stomachCapacity = 100;
        private int stomachFullness = 100;
        public int StomachCapacity
        {
            get { return stomachCapacity; }
            set
            {
                if (value >= 1 && value <= 100)
                {
                    stomachCapacity = value;
                }
                else
                {
                    throw new Exception("Invalid input parameters.");
                }
            }
        }
        public int HungrinessCoefficient
        {
            get { return hungrinessCoefficient; }
            set
            {
                if (value >= 1 && value <= 99)
                {
                    hungrinessCoefficient = value;
                }
                else
                {
                    throw new Exception("Invalid input parameters.");
                }
            }
        }
        public int StomatchFullness
        {
            get { return stomachFullness; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    stomachFullness = value;
                }
                else
                {
                    throw new Exception("Invalid input parameters.");
                }
            }
        }
        public Stomach()
        {

        }
        public Stomach(int stomachCapacit, int stomachFullnes)
        {
            this.StomachCapacity = stomachCapacit;
            this.StomatchFullness = stomachFullness;
        }
    }
}
