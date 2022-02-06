namespace Zoo_Project
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
        public Stomach(int stomachCapacity, int stomachFullness, int hungrinessCoefficient)
        {
            this.StomachCapacity = stomachCapacity;
            this.StomatchFullness = stomachFullness;
            this.HungrinessCoefficient = hungrinessCoefficient;
        }
        public void SetStomachProperties(int hungrinessCoefficient)
        {
            this.HungrinessCoefficient = hungrinessCoefficient;
        }
        public void SetStomachProperties(int hungrinessCoefficient, int stomachCapacity)
        {
            this.HungrinessCoefficient = hungrinessCoefficient;
            this.StomachCapacity = stomachCapacity;
        }
        public void SetStomachProperties(int hungrinessCoefficient, int stomachCapacity, int stomachFullness)
        {
            this.HungrinessCoefficient = hungrinessCoefficient;
            this.StomachCapacity = stomachCapacity;
            this.StomatchFullness = stomachFullness;
        }
        public bool IsStomachEmpty() => this.StomatchFullness == 0 ? true : false;



    }
}
