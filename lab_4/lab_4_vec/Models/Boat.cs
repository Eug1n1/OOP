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
            return GetInfo() + " " + CommonInfo.Title + " " + CommonInfo.CaptainName;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Boat(CommonInfo info) : base(info)
        {
        }
    }
}