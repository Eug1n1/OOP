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

        public static Vector abs(this Vector vector)
        {
            vector.X = Math.Abs(vector.X);
            vector.Y = Math.Abs(vector.Y);
            return vector;
        }

        public static Vector Sum(Vector vec1, Vector vec2)
        {
            return vec1 + vec2;
        }

        public static double diff(Vector vec1, Vector vec2)
        {
            return Math.Abs(Math.Sqrt((vec1.X ^ 2) + (vec1.Y ^ 2)) - Math.Sqrt((vec2.X ^ 2) + (vec2.Y ^ 2)));
        }
        
        
        
    }
}