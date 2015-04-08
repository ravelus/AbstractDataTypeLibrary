using System;
using System.Collections.Generic;

namespace TAD_Library.Sorting
{
    interface ISorter<T> where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
