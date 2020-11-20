using System;
using System.Collections.Generic;

namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyOwnShip("stella", 12);
            Console.WriteLine(a.GetInfo());
            a.DoClone();
            
            Ship b = new Steamboat("Steam", 30);
            /*Ship ab = b;*/
            Console.WriteLine(b.GetInfo());
            
            var c = new Boat("boat", 5);
            var d = new Corvette("corvette", 40);
            var e = new MyOwnShip("Mine", 90);
            var f = new Printer();
            var g = new Sailboat("sailboat", 20);
            var h = new Steamboat("steamboat", 30);

            List<Ship> list = new List<Ship>();
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(g);
            list.Add(h);

            foreach (var l in list)
            {
                f.IAmPrinting(l);
            }

            
            Console.WriteLine(((Ship)c).GetInfo());
        }
    }
}
