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
            var vec = new Vector();
            vec.X = vec1.X + vec2.X;
            vec.Y = vec1.Y + vec2.Y;
            
            return vec;
        }
    }
}