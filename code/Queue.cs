using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAD_Library
{
    public class Queue<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Enqueue(T value)
        {
            _items.AddFirst(value);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T last = _items.Tail.Value;

            _items.RemoveLast();

            return last;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _items.Tail.Value;
        }
    }
}
