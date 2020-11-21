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
            return GetInfo() + " " + CommonInfo.Title + " " + CommonInfo.CaptainName;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Corvette(CommonInfo info) : base(info)
        {
        }
    }
}