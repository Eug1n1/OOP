using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_10
{
    public class MyList<T> : IList<T>
    {
        private T[] _list;
        private int _capacity;
        private int _count;
        private readonly int _lockedCapacity = -1;
        
        public int Count => _count;

        public int Capacity
        {
            get => _capacity;
            set
            {
                if(value < 0)
                    throw new ArgumentException();

                if (_capacity < value)
                {
                    var newArr = new T[value];
                    _list.CopyTo(newArr, 0);

                    _list = newArr;
                }

                _capacity = value;
            }
        }

        public bool IsReadOnly { get; set; } = false;
        
        public T this[int index]
        {
            get => _list[index];
            set
            {
                if(index < 0 || (_lockedCapacity != -1 && index > _lockedCapacity))
                    throw new ArgumentException("Incorrect index value");
                
                _list[index] = value;
            }
        }
        

        public MyList()
        {
            _count = 0;
            _capacity = 255;
            _list = new T[_capacity];
        }
        
        public MyList(int capacity)
        {
            _lockedCapacity = capacity;
            _list = new T[_lockedCapacity];
            _count = 0;
        }

        public MyList(T[] arr)
        {
            _list = arr;
            _count = arr.Length;
            
            if(_count > 255)
                _capacity = _count + 1;

            _capacity = 255;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnum<T>(_list, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (IsReadOnly)
                throw new Exception("MyList is Readonly now!");
            
            if(_lockedCapacity != -1 && _lockedCapacity == _count)
                throw new Exception("List is full!");

            if (_lockedCapacity == -1 && _capacity == _count)
            {
                var newArr = new T[_capacity + 1];
                _list.CopyTo(newArr, 0);

                newArr[_count] = item;
                _list = newArr;

                _count++;
                _capacity++;
            }
            _list[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _list = new T[_capacity];
        }

        public bool Contains(T item)
        {
            foreach (var element in _list)
            {
                // ReSharper disable once PossibleNullReferenceException
                if (item.Equals(element))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex, j = 0; i < _count - 1; i++, j++)
            {
                array[i] = _list[j];
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                if (item.Equals(_list[i]))
                {
                    for (int j = i; j < _count; j++)
                        _list[j] = _list[j + 1];
                    _count--;
                    
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                if (item.Equals(_list[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly)
                throw new Exception("List is Readonly now!");
            
            if(_lockedCapacity != -1 && _lockedCapacity == _count)
                throw new Exception("List is full!");

            if (_lockedCapacity == -1 && _capacity == _count)
            {
                var newArr = new T[_capacity + 1];
                _list.CopyTo(newArr, 0);
                _list = newArr;
                
                _capacity++;
            }
            
            for (int i = _count; i >= index; i--)
            {
                _list[i] = _list[i - 1];
            }
            _count++;

            _list[index] = item;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index > _count - 1)
                throw new ArgumentException("Incorrect index value!");
            
            for (int i = index; i < _count; i++)
            {
                _list[i] = _list[i + 1];
            }
        }
    }
}