namespace lab_5
{
    public abstract class Ship : IVehicle
    {
        public string Title { get; set; }
        public int MaxSpeed { get; set; }
        
        
        protected Ship(string title, int maxSpeed)
        {
            Title = title;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return "Oh damn! Hey Man it is abstract class";
        }


        public virtual string GetInfo()
        {
            return "Это корабль";
        }

        public abstract bool DoClone();

    }
}