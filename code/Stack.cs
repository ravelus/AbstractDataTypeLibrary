using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractDataTypeLibrary
{
    public class Stack<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Push(T value)
        {
            _items.AddLast(value);
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = _items.Tail.Value;

            _items.RemoveLast();

            return result;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items.Tail.Value;
        }
    }
}
