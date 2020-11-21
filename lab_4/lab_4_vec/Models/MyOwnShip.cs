using System;

namespace lab_5
{
    public sealed partial class MyOwnShip : Ship, IVehicle
    {
        public override bool DoClone()
        {
            Console.WriteLine("abstract class");
            return false;
        }

        bool IVehicle.DoClone()
        {
            Console.WriteLine("interface");
            return true;
        }


        public MyOwnShip(CommonInfo info) : base(info)
        {
        }
    }
}