using System;

namespace _20240823_HW_Delegate;

public abstract class SortDoubleArray
{
    protected double[] _sortArray;
    protected IterationDateTimeDelegate _startTime;
    protected IterationDateTimeDelegate _finishTime;
    protected ExchangeCountIn1dArrayDelegate _exchangeCount;
    protected SwapCountIn1dArrayDelegate _swapCount;

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

    public event ExchangeCountIn1dArrayDelegate ExchangeCount
    {
        add => _exchangeCount += value;
        remove => _exchangeCount -= value;
    }

    public event SwapCountIn1dArrayDelegate SwapCount
    {
        add => _swapCount += value;
        remove => _swapCount -= value;
    }

    public abstract void Sort();

    public void RunSort()
    {
        _startTime?.Invoke(this, DateTime.Now);
        Sort();
        _finishTime?.Invoke(this, DateTime.Now); 
    }
}
