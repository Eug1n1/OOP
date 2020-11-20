using System;

namespace lab_5
{
    public class Printer
    {
        public void IAmPrinting(Ship ship)
        {
            if (ship is Steamboat steamboat)
            {
                Console.WriteLine(steamboat.ToString());
            }
            else if (ship is Boat boat)
            {
                Console.WriteLine(boat.ToString());
            }
            else if (ship is MyOwnShip myOwnShip)
            {
                Console.WriteLine(myOwnShip.ToString());
            }
            else if (ship is Corvette corvette)
            {
                Console.WriteLine(corvette.ToString());
            }
            else if (ship is Sailboat sailboat)
            {
                Console.WriteLine(sailboat.ToString());
            }
            else
            {
                Console.WriteLine(ship.ToString());
            }
        }
    }
}