using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_3
{
    public class MultitudeEnumerator<T> : IEnumerator
    {
        public T[] _mlt;
        
        private int position = -1;

        private int _length;

        public MultitudeEnumerator(T[] list, int length)
        {
            _mlt = list;
            _length = length;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _length);
        }

        public void Reset()
        {
            position = -1;
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
                    return _mlt[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}