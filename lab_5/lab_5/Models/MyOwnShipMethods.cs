namespace lab_5
{
    public partial class MyOwnShip
    {
        public override string GetInfo()
        {
            return "Это мой корабль";
        }

        public override string ToString()
        {
            return GetInfo() + " " + CommonInfo.Title + " " + CommonInfo.CaptainName;
        }
    }
}