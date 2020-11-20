using System.Collections.Generic;

namespace lab_4_vec
{
    public class MyVector<T>
    {
        public class ProjectOwner
        {
            public int Id { get; private set; }    
            public string Name { get; private set; }
            public string Organization { get; private set; }
            public ProjectOwner()
            {
            }

            public ProjectOwner(int id, string name, string organization)
            {
                Id = id;
                Name = name;
                Organization = organization;
            }        
        }
        
        public List<T> Items { get; set; }

        public ProjectOwner Owner = new ProjectOwner(1, "Evgeniy Shumskiy", "BSTU Student");
        


        public MyVector()
        {
            Items = new List<T>();
        }
        
        public MyVector(List<T> list)
        {
            Items = list;
        }

        public MyVector(params MyVector<T>[] a)
        {
            Items = new List<T>();
            foreach (var my in a)
            {
                Items.AddRange(my.Items);        
            }
        }

        public static MyVector<T> operator +(MyVector<T> vec1, MyVector<T> vec2)
        {
            return new MyVector<T>(vec1, vec2);
        }

        public static bool operator >(MyVector<T> vec1, MyVector<T> vec2)
        {
            return vec1.Items.Count > vec2.Items.Count;
        }

        public static bool operator <(MyVector<T> vec1, MyVector<T> vec2)
        {
            return vec1.Items.Count < vec2.Items.Count;
        }
        
        public static bool operator ==(MyVector<T> vec1, MyVector<T> vec2)
        {
            return vec1.Items == vec2.Items;
        }
        
        public static bool operator !=(MyVector<T> vec1, MyVector<T> vec2)
        {
            return vec1.Items != vec2.Items;
        }
        
        public static bool operator true(MyVector<T> vec)
        {
            return vec.Items != null;
        }

        public static bool operator false(MyVector<T> vec)
        {
            return vec.Items == null;
        }

        public override string ToString()
        {
            var str = "";
            
            foreach (var item in Items)
            {
                str += item.ToString() + " ";
            }
            return str;
        }
    }
}