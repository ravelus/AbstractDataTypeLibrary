using System;
using System.Collections;
using System.Collections.Generic;

namespace TAD_Library
{
    public class ArrayList<T> : IList<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return _items[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index < Count)
                {
                    _items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public ArrayList() : this(0)
        {
        }

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length must be equal or bigger than zero.");
            }

            _items = new T[length];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Add(T item)
        {
            if (_items.Length == Count)
            {
                GrowArray();
            }

            _items[Count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (_items.Length == this.Count)
            {
                GrowArray();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            int shiftStart = index + 1;
            if (shiftStart < Count)
            {
                Array.Copy(_items, shiftStart, _items, index, Count - shiftStart);
            }

            if (Count > 0)
            {
                Count--;
            }
        }

        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void GrowArray()
        {
            int newLength = _items.Length == 0 ? INITIAL_GROW_AMOUNT : _items.Length << 1;

            T[] newArray = new T[newLength];

            _items.CopyTo(newArray, 0);

            _items = newArray;
        }

        private T[] _items;

        private const int INITIAL_GROW_AMOUNT = 16;
    }
}
