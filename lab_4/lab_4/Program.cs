using System;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var vec1 = new Vector(4, -5);
            var vec2 = new Vector(1, 5);

            if (vec1 > vec2)
            {
                Console.WriteLine("da");
            }
            
            var vec = new Vector();
            vec = vec1 + vec2;
            Console.WriteLine(vec.ToString());

            var a = "dklfncnbkl";
            a = a.usech(6);
            Console.WriteLine(a);

            Console.WriteLine(vec1.ToString());
            vec1 = vec1.abs();
            Console.WriteLine(vec1.ToString());
            
            
        }
    }
}
