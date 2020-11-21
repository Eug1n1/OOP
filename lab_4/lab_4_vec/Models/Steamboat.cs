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
            return GetInfo() + " " + CommonInfo.Title + " " + CommonInfo.CaptainName;
        }

        public override bool DoClone()
        {
            throw new System.NotImplementedException();
        }

        public Steamboat(CommonInfo info) : base(info)
        {
        }
    }
}