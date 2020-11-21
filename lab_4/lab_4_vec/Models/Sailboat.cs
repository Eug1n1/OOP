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
            return GetInfo() + " " + CommonInfo.Title + " " + CommonInfo.CaptainName;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }


        public Sailboat(CommonInfo info) : base(info)
        {
        }
    }
}