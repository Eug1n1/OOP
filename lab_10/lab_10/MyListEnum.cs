using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_10
{
    public class MyListEnum<T> : IEnumerator<T>
    {
        private readonly T[] _mlt;


        private int _position = -1;
        private readonly int _length;

        public MyListEnum(T[] list, int length)
        {
            _mlt = list;
            _length = length;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _mlt[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}