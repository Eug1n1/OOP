using System.Collections;
using System.Collections.Generic;

namespace lab_3
{
    public class Multitude<T> : IEnumerable
    {
        #region Поля и свойства

        private readonly T[] _multitudes;

        public int Length { get; private set; } = 0;

        public int Capacity { get; private set; } = 1024;
        
        public T this[int j] => _multitudes[j];

        #endregion

        #region Конструкторы

        public Multitude()
        {
            _multitudes = new T[Capacity];
        }
        
        public Multitude(int capacity)
        {
            _multitudes = new T[capacity];
            Capacity = capacity;
        }

        public Multitude(T[] array)
        {
            _multitudes = array;
            Length = array.Length;
        }

        public Multitude(List<T> list)
        {
            _multitudes = list.ToArray();
            Length = list.Count;
            Capacity = list.Capacity;
        }

        #endregion

        #region Методы

        public void Add(T num)
        {
            _multitudes[Length] = num;
            Length++;
        }

        public void Delete(int index)
        {
            for (int i = 0; i < Length; i++)
            {
                _multitudes[index + i] = _multitudes[index + i + 1];
            }

            Length--;
        }

        public static Multitude<T> Create(int capacity)
        {
            return new Multitude<T>(capacity);
        }

        #endregion
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public MultitudeEnumerator<T> GetEnumerator()
        {
            return new MultitudeEnumerator<T>(_multitudes, Length);
        }
    }
}