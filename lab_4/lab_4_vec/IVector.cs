using System.Collections.Generic;

namespace lab_4_vec
{
    public interface IVector<T>
    {
        public List<T> Items { get; set; }

        public static IVector<T> operator +(IVector<T> vec1, IVector<T> vec2)
        {
            throw new System.NotImplementedException();
        }
        
        public static bool operator >(IVector<T> vec1, IVector<T> vec2)
        {
            throw new System.NotImplementedException();
        }
        
        public static bool operator <(IVector<T> vec1, IVector<T> vec2)
        {
            return vec1.Items.Count < vec2.Items.Count;
        }

        public static bool operator true(IVector<T> vec)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator false(IVector<T> vec)
        {
            throw new System.NotImplementedException();
        }
    }
}