namespace lab_5
{
    public class Corvette : Ship
    {
        public override string GetInfo()
        {
            return "Это корвет";
        }
        
        public override string ToString()
        {
            return GetInfo() + " " + Title + " " + MaxSpeed;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Corvette(string title, int maxSpeed) : base(title, maxSpeed)
        {
        }
    }
}