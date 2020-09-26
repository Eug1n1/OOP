using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlt = Multitute.Create(10);
            var m = Multitute.Create(10);

            try
            {
                m.Add(1);
                m.Add(2);
                m.Add(3);
                m.Add(4);
                m.Add(22);
                m.Add(57);
                m.Add(534);
                m.Add(54);
                m.Add(34);
                m.Add(53);

                
                mlt.Add(1);
                mlt.Add(2);
                mlt.Add(3);
                mlt.Add(4);
                mlt.Add(22);
                mlt.Add(57);
                mlt.Add(534);
                mlt.Add(54);
                mlt.Add(34);
                mlt.Add(53);

                Console.WriteLine(mlt.Equals(m));
                Console.WriteLine(mlt.GetHashCode());
                Console.WriteLine(m.GetHashCode());

                Console.WriteLine($"mlt id: {mlt.ID}\n");
                foreach (var mm in mlt)
                {
                    Console.WriteLine(mm);
                }

                Console.WriteLine(Multitute.ElementsCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
