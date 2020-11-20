namespace lab_5
{
    public class Sailboat : Ship
    {
        public override string GetInfo()
        {
            return "Это парусник";
        }

        public override string ToString()
        {
            return GetInfo() + Title + " " + MaxSpeed;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }


        public Sailboat(string title, int maxSpeed) : base(title, maxSpeed)
        {
        }
    }
}