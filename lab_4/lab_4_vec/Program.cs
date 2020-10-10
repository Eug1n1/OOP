using System;

namespace lab_4_vec
{
    class Program
    {
        static void Main(string[] args)
        {
            MyVector<int> a = new MyVector<int>();
            a.Items.Add(12);
            a.Items.Add(13);
            a.Items.Add(14);
            a.Items.Add(15);
            a.Items.Add(16);
            
            MyVector<int> b = new MyVector<int>();
            b.Items.Add(6);
            b.Items.Add(73);
            b.Items.Add(84);
            b.Items.Add(95);
            b.Items.Add(16);

            a.Items[1] = 0;

            a = a + b;

            Console.WriteLine(a.ToString());
        }
    }
}