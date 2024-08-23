using System;

namespace _20240823_HW_Delegate;

public abstract class SortDoubleArray
{
    protected double[] _sortArray;

    public SortDoubleArray(double[] arrayToSort)
    {
        _sortArray = (double[])arrayToSort.Clone();
        // _sortArray = arrayToSort;
    }

    public double[] SortArray
    {
        get => _sortArray;
    }

    public abstract void Sort();
}
