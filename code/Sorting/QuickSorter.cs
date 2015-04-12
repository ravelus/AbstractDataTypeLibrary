using System;
using System.Collections.Generic;

namespace AbstractDataTypeLibrary.Sorting
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        Random _pivotRng = new Random();

        public void Sort(T[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private void QuickSort(T[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = CalculatePivot(items, left, right, pivotIndex);

                QuickSort(items, left, newPivot - 1);
                QuickSort(items, newPivot + 1, right);
            }
        }

        private int CalculatePivot(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            SorterHelper<T>.Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    SorterHelper<T>.Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            SorterHelper<T>.Swap(items, storeIndex, right);
            return storeIndex;
        }

    }
}
