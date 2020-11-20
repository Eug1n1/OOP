using System;

namespace lab_5
{
    public sealed class MyOwnShip : Ship, IVehicle
    {
        public override bool DoClone()
        {
            Console.WriteLine("abstract class");
            return false;
        }

        public override string GetInfo()
        {
            return "Это мой корабль";
        }

        public override string ToString()
        {
            return GetInfo() + Title + " " + MaxSpeed;
        }

        bool IVehicle.DoClone()
        {
            Console.WriteLine("interface");
            return true;
        }

        public MyOwnShip(string title, int maxSpeed) : base(title, maxSpeed)
        {
        }
    }
}