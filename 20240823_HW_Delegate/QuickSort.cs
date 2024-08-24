using System;

namespace _20240823_HW_Delegate;

public class QuickSort : SortDoubleArray
{
    public QuickSort(double[] arrayToSort) : base(arrayToSort)
    {
    }

    public override void Sort()
    {
        QuickSortMehod(0, _sortArray.Length - 1);
    }

    private void QuickSortMehod(int low, int high)
    {
        if (low < high)
        {
            double pivot = _sortArray[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (_sortArray[j] <= pivot)
                {
                    i++;
                    double temp = _sortArray[i];
                    _sortArray[i] = _sortArray[j];
                    _sortArray[j] = temp;
                    _swapCount?.Invoke(this, i);
                }
            }

            double temp1 = _sortArray[i + 1];
            _sortArray[i + 1] = _sortArray[high];
            _sortArray[high] = temp1;
            _exchangeCount?.Invoke(this, i);

            int index = i + 1;

            QuickSortMehod(low, index - 1);
            QuickSortMehod(index + 1, high);
        }
    }
}
