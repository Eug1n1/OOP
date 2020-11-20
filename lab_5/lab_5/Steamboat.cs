namespace lab_5
{
    public class Steamboat : Ship
    {
        public override string GetInfo()
        {
            return "Это пароход";
        }
        
        public override string ToString()
        {
            return GetInfo() + " " + Title + " " + MaxSpeed;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Steamboat(string title, int maxSpeed) : base(title, maxSpeed)
        {
        }
    }
}