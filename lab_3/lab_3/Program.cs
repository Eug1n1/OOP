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
                mlt.Add(22);
                mlt.Add(57);
                mlt.Add(534);
                
                mlt.DeleteIndex(3);
                mlt.Delete(534);

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
