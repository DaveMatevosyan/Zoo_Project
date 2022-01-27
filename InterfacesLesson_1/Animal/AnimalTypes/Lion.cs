namespace Zoo_Project
{
    public class Lion : Animal, IWalkable
    {
        public override List<IFood> Foods { get; set; } = new List<IFood>() { new Meat() };
        public Lion() :base()
        {
            this.Name = this.GetType().Name;
            //this.Stomach = new Stomach();
        }
        public Lion(string name, GenderType gender) : base()
        {
            this.Name = name;
            this.Gender = gender;
        }
        public override void Sound()
        {
            Console.WriteLine("Lion sound.");
        }
        public void Walk()
        {
            Console.WriteLine("Lion walk.");
        }
    }
}
