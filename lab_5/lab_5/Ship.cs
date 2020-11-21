namespace lab_5
{
    public abstract class Ship : IVehicle
    {
        public CommonInfo CommonInfo { get; set; }
        
        public Ship(CommonInfo info)
        {
            CommonInfo = info;
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