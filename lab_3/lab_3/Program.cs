using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlt = new Multitute<int>(10);

            try
            {
                mlt.Add(1);
                mlt.Add(2);
                mlt.Add(3);
                mlt.Add(55);
                
                mlt.Delete(3);

                foreach (var m in mlt)
                {
                    Console.WriteLine(m);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
