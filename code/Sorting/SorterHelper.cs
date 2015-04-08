using System;
using System.Collections.Generic;

namespace TAD_Library.Sorting
{
    internal static class SorterHelper<T> where T : IComparable<T>
    {
        internal static void Swap(T[] items, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            T temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }
    }
}
