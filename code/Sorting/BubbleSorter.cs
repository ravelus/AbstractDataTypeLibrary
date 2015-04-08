using System;
using System.Collections.Generic;

namespace TAD_Library.Sorting
{
    public class BubbleSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        SorterHelper<T>.Swap(items, i - 1, i);
                        swapped = true;
                    }
                }

            } while (!swapped);
        }
    }
}
