using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var dmlt = new Multitude<double>();
            dmlt.Add(1.5);
            dmlt.Add(3.7);
            dmlt.Add(9.1);

            foreach (var d in dmlt)
            {
                Console.WriteLine(d);
            }
        }
    }
}
