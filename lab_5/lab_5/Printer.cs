using System;

namespace lab_5
{
    public class Printer
    {
        public void IAmPrinting(Ship ship)
        {
            Console.WriteLine(ship.ToString());
        }
    }
}