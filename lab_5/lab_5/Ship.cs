namespace lab_5
{
    public abstract class Ship : IVehicle
    {
        public virtual string GetInfo()
        {
            return "Это корабль";
        }

        public virtual bool DoClone()
        {
            return false;
        }
    }
}