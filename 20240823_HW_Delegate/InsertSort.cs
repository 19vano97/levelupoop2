using System;

namespace _20240823_HW_Delegate;

public class InsertSort : SortDoubleArray
{
    public InsertSort(double[] arrayToSort) : base(arrayToSort)
    {
    }

    public override void Sort()
    {
        for (int i = 0; i < _sortArray.Length; i++)
        {
            int insertIndex = i;
            double currentValue = _sortArray[i];

            for (int y = i - 1; y >= 0; y--)
            {
                if (_sortArray[y] > currentValue)
                {
                    double temp = _sortArray[y];
                    _sortArray[y] = _sortArray[y + 1];
                    _sortArray[y + 1] = temp;
                    insertIndex = y;
                }
                else
                {
                    break;
                }
            }

            _sortArray[insertIndex] = currentValue;
        }
    }
}
