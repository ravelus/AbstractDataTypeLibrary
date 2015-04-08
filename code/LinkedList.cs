using System;
using System.Collections;
using System.Collections.Generic;

namespace TAD_Library
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public void AddFirst(T value)
        {
            LinkedListNode<T> nodeToAdd = new LinkedListNode<T>(value);

            LinkedListNode<T> temp = Head;

            Head = nodeToAdd;

            Head.Next = temp;

            if (Count == 0)
            {
                // head and tail match
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> nodeToAdd = new LinkedListNode<T>(value);

            if (Count == 0)
            {
                Head = nodeToAdd;
            }
            else
            {
                Tail.Next = nodeToAdd;
                nodeToAdd.Previous = Tail;
            }

            Tail = nodeToAdd;
            Count++;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //May throw an IndexOutOfRange exception that the caller will handle

            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                return;
            }

            Head = Head.Next;

            Count--;

            if (Count == 0)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                return;
            }

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
            }

            Count--;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (!current.Value.Equals(item))
                {
                    previous = current;
                    current = current.Next;
                    continue;
                }

                if (previous == null)
                {
                    RemoveFirst();
                    return true;
                }

                // Remove the item
                previous.Next = current.Next;

                // If it was the latest item, update the tail
                if (current.Next == null)
                {
                    Tail = previous;
                }
                else
                {
                    current.Next.Previous = previous;
                }

                Count--;
                return true;
            }

            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

    public class LinkedListNode<U>
    {
        public U Value { get; internal set; }

        public LinkedListNode<U> Next { get; internal set; }

        public LinkedListNode<U> Previous { get; internal set; }

        public LinkedListNode(U value)
        {
            Value = value;
        }
    }
}
