using System;

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
        
        
    }
}