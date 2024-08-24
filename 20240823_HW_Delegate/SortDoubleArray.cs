using System;

namespace _20240823_HW_Delegate;

public abstract class SortDoubleArray
{
    protected double[] _sortArray;
    protected IterationDateTimeDelegate _startTime;
    protected IterationDateTimeDelegate _finishTime;

    public SortDoubleArray(double[] arrayToSort)
    {
        _sortArray = (double[])arrayToSort.Clone();
    }

    public double[] SortArray
    {
        get => _sortArray;
    }

    public event IterationDateTimeDelegate StartTime
    {
        add => _startTime += value;
        remove => _startTime -= value;
    }

    public event IterationDateTimeDelegate FinishTime
    {
        add => _finishTime += value;
        remove => _finishTime -= value;
    }

    public abstract void Sort();

    public void RunSort()
    {
        _startTime?.Invoke(this, DateTime.Now);
        Sort();
        _finishTime?.Invoke(this, DateTime.Now); 
    }
}
