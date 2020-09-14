using System;
using System.Collections;
using System.Linq;

namespace lab_3
{
    public class Multitute<T> : IEnumerable
    {

        #region Поля и Свойства
        
        // TODO: реализовать мин и макс значения
        
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
            // TODO: Проверка на мин макс
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