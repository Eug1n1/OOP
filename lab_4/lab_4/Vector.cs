using System;

namespace lab_4
{
    public class Vector
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                _y = value;
            }
        }

        public Data Time;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
            Time = new Data();
        }
        
        public Vector()
        {
            X = 0;
            Y = 0;
            Time = new Data();
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y );
        }

        public static bool operator >(Vector vec1, Vector vec2)
        {
            return Math.Sqrt((vec1.X ^ 2) + (vec1.Y ^ 2)) > Math.Sqrt((vec1.X ^ 2 + vec1.Y ^ 2));
        }

        public static bool operator <(Vector vec1, Vector vec2)
        {
            return Math.Sqrt((vec1.X ^ 2) + (vec1.Y ^ 2)) < Math.Sqrt((vec1.X ^ 2 + vec1.Y ^ 2));
        }
        
        public static bool operator ==(Vector vec1, Vector vec2)
        {
            return vec1.X == vec2.X && vec1.Y == vec2.Y;
        }

        public static bool operator !=(Vector vec1, Vector vec2)
        {
            return !(vec1 == vec2);
        }

        public static bool operator true(Vector vec)
        {
            return vec.X != 0 || vec.Y != 0;
        }

        public static bool operator false(Vector vec)
        {
            return vec.X == 0 && vec.Y == 0;
        }

        public override string ToString()
        {
            return $"( {X}, {Y} )";
        }
    }

    public class Data
    {
        public DateTime Time { get; private set; }

        public Data()
        {
            Time = DateTime.Now;
        }
    }
}