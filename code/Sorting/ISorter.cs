using System;
using System.Collections.Generic;

namespace AbstractDataTypeLibrary.Sorting
{
    interface ISorter<T> where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
