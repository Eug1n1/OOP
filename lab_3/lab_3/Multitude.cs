using System;
using System.Collections;
using System.Linq;

namespace lab_3
{
    public partial class Multitute : IEnumerable
    {

        #region Поля и Свойства
        
        private static int _elementsCount;

        private readonly int[] _multitudes;

        public static int ElementsCount => _elementsCount;

        public readonly int ID;
        public int Length { get; private set; } = 0;

        public int Capacity { get; private set; } = 1024;

        public int this[int j] => _multitudes[j];

        public int Sum;

        #endregion

        #region Конструктор

        public Multitute()
        {
            _elementsCount++;
            _multitudes = new int[Capacity];
            ID = new Random().Next(0, 256);
        }
        
        public Multitute(int capacity)
        {
            _elementsCount++;
            Capacity = capacity;
            _multitudes = new int[Capacity];
            ID = new Random().Next(0, 256);
        }
        
        public Multitute(int[] arr)
        {
            _elementsCount++;
            _multitudes = arr;
            Capacity = arr.Length;
            Length = arr.Length;
            ID = new Random().Next(0, 256);
        }

        static Multitute()
        {
            _elementsCount = 0;
        }
        
        #endregion

        #region Enum
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private MultitudeEnum<int> GetEnumerator()
        {
            return new MultitudeEnum<int>(_multitudes, Length);
        }

        #endregion
       
    }
}