using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using lab_4_vec;

namespace lab_4
{
    public static class StatisticOperation
    {
        public static string usech(this string a, int num = 1)
        {
            if(num > a.Length)
                throw new Exception("kuda pihaesh?");
            
            return a.Substring(a.Length - (a.Length - num), a.Length - num);
        }

        public static MyVector<int> Abs(this MyVector<int> vec)
        {
            var list = new List<int>();
            foreach (var i in vec.Items)
            {
                list.Add(Math.Abs(i));
            }
            
            return new MyVector<int>(list);
        }

        public static int Count(this MyVector<int> vec)
        {
            return vec.Items.Count;
        }
        
        public static int Sum(this MyVector<int> vec)
        {
            return vec.Items.Sum();
        }

        public static int BestMethod(this MyVector<int> vec)
        {
            return vec.Items.Max() - vec.Items.Min();
        }
    }
}