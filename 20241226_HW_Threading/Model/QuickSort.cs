using System;

namespace _20241226_HW_Threading.Model;

public class QuickSort : SortDoubleArray
{
    public QuickSort(double[] doubles) : base(doubles)
    {
    }

    protected override void Sort()
    {
        QuickSortMehod(0, _doubles.Length - 1);
    }

    private void QuickSortMehod(int low, int high)
    {
        if (low < high)
        {
            double pivot = _doubles[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (_doubles[j] <= pivot)
                {
                    i++;
                    double temp = _doubles[i];
                    _doubles[i] = _doubles[j];
                    _doubles[j] = temp;
                }
            }

            double temp1 = _doubles[i + 1];
            _doubles[i + 1] = _doubles[high];
            _doubles[high] = temp1;
            int index = i + 1;
            
            QuickSortMehod(low, index - 1);
            QuickSortMehod(index + 1, high);
        }
    }
    
}
