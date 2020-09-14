using System;
using System.Collections;
using System.Linq;

namespace lab_3
{
    public class Multitute<T> : IEnumerable
    {

        #region Поля и Свойства

        public int Length { get; private set; } = 0;

        public int Capacity { get; private set; } = 1024;

        private readonly T[] _multitudes;
        
        public T this[int j] => _multitudes[j];

        #endregion

        #region Конструктор

        public Multitute()
        {
            _multitudes = new T[Capacity];
        }
        
        public Multitute(int capacity)
        {
            Capacity = capacity;
            _multitudes = new T[Capacity];
        }
        
        public Multitute(T[] arr)
        {
            _multitudes = arr;
            Capacity = arr.Length;
            Length = arr.Length;
        }

        #endregion

        #region Методы

        public void Add(T element)
        {
            if (Exist(element))
            {
                throw new Exception("element already exist");
            }
            else
            {
                _multitudes[Length] = element;
                Length++;
            }

        }

        public void Delete(int index)
        {
            for (var i = 0; i < Length; i++)
            {
                _multitudes[index + i] = _multitudes[index + 1 + i];
            }
            Length--;
        }
        
        private bool Exist(T element)
        {
            return _multitudes.Any(mlt => mlt.ToString() == element.ToString());
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MultitudeEnum<T> GetEnumerator()
        {
            return new MultitudeEnum<T>(_multitudes, Length);
        }

        #endregion
       
    }
}