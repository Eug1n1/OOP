using System;
using System.Linq;

namespace lab_3
{
    public partial class Multitute
    {
        #region Методы

        public void Add(int element)
        {
            if (Exist(element))
                throw new Exception($"element {element} already exist");
            
            if(Length == Capacity)
                throw new Exception("Array is full");
            
            else
            {
                _multitudes[Length] = element;
                Length++;
            }
        }

        public void Delete(int num)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_multitudes[i].ToString() == num.ToString())
                {
                    for (var j = i; j < Length - 1; j++)
                    {
                        _multitudes[j] = _multitudes[j + 1];
                    } 
                    Length--;
                    return;
                }       
            }
        }
        public void DeleteIndex(int index)
        {
            for (var j = index; j < Length - 1; j++)
            {
                    _multitudes[j] = _multitudes[j + 1];
            } 
            Length--;
        }

        public static Multitute Create(int capacity = 1024)
        {
            return new Multitute(capacity);
        }

        public override string ToString()
        {
            return _multitudes.Aggregate("{ ", (current, mlt) => current + $"{mlt} ") + " }";;
        }

        public bool Equals(Multitute obj)
        {
            if (obj == null || obj.Length != Length)
                return false;
            
            var i = 0;
            foreach (var m in obj){
                if (!_multitudes[i++].Equals(m))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < ID; i++)
            {
                hash += ID;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            
            return (hash < 0 ? Math.Abs(hash) : hash);
        }

        private bool Exist(int element)
        {
            return _multitudes.Any(mlt => mlt.ToString() == element.ToString());
        }

        #endregion
    }
}