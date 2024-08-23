using System;

namespace _20240823_HW_Delegate;

public class BubbleSort : SortDoubleArray
{
    public BubbleSort(double[] arrayToSort) : base(arrayToSort)
    {
    }

    public override void Sort()
    {
        for (int i = 0; i < _sortArray.Length - 1; i++)
        {
            for (int k = 0; k < _sortArray.Length - i - 1; k++)
            {
                if (_sortArray[k] > _sortArray[k + 1])
                {
                    double temp = _sortArray[k];
                    _sortArray[k] = _sortArray[k + 1];
                    _sortArray[k + 1] = temp;
                }
            }
        }
    }
}
