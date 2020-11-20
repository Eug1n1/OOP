namespace lab_5
{
    public class Boat : Ship
    {
        public override string GetInfo()
        {
            return "Это лодка";
        }
        
        public override string ToString()
        {
            return GetInfo() + Title + " " + MaxSpeed;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Boat(string title, int maxSpeed) : base(title, maxSpeed)
        {
        }
    }
}