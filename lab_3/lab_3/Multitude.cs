using System;
using System.Collections;
using System.Linq;

namespace lab_3
{
    public class Multitute<T> : IEnumerable
    {

        #region Поля и Свойства
        
        // TODO: реализовать мин и макс значения

        public readonly int ID;
        public int Length { get; private set; } = 0;

        public int Capacity { get; private set; } = 1024;

        private readonly T[] _multitudes;
        
        public T this[int j] => _multitudes[j];

        public T Sum;

        #endregion

        #region Конструктор

        public Multitute()
        {
            _multitudes = new T[Capacity];
            ID = new Random().Next(0, 256);
        }
        
        public Multitute(int capacity)
        {
            Capacity = capacity;
            _multitudes = new T[Capacity];
            ID = new Random().Next(0, 256);
        }
        
        public Multitute(T[] arr)
        {
            _multitudes = arr;
            Capacity = arr.Length;
            Length = arr.Length;
            ID = new Random().Next(0, 256);
        }
        
        #endregion

        #region Методы

        public void Add(T element)
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

        public void Delete(T num)
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

        public static Multitute<T> Create(int capacity = 1024)
        {
            return new Multitute<T>(capacity);
        }

        public override string ToString()
        {
            var str = _multitudes.Aggregate("{ ", (current, mlt) => current + $"{mlt} ") + " }";
            
            return str;
        }

        public bool Equals(Multitute<T> obj)
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

        public long GetHashCode()
        {
            long hash = 0;

            for (int i = 0; i < ID; i++)
            {
                hash += ID;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            
            return hash < 0 ? Math.Abs(hash) : hash;
        }

        private bool Exist(T element)
        {
            return _multitudes.Any(mlt => mlt.ToString() == element.ToString());
        }

        #endregion

        #region Enum
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private MultitudeEnum<T> GetEnumerator()
        {
            return new MultitudeEnum<T>(_multitudes, Length);
        }

        #endregion
       
    }
}