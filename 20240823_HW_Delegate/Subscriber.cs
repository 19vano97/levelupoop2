using System;

namespace _20240823_HW_Delegate;

public class Subscriber
{
    private SortDoubleArray _sort;
    private ulong _swapCount;
    private ulong _exchangeCount;
    private DateTime _startDate;
    private DateTime _finishTime;

    public Subscriber(SortDoubleArray s)
    {
        _sort = s;
        s.ExchangeCount += CalcExchnageCount;
        s.SwapCount += CalcSwapsCount;
        s.StartTime += GetStartTime;
        s.FinishTime += GetFinishTime;
    }

    public ulong ExchangeCount
    {
        get => _exchangeCount;
    }

    public ulong SwapCount
    {
        get => _swapCount;
    }

    public DateTime StartTime
    {
        get => _startDate;
    }

    public DateTime FinishTime
    {
        get => _finishTime;
    }

    public void CalcExchnageCount(object sender, int iteration)
    {
        ++_exchangeCount;
    }

    public void CalcSwapsCount(object sender, int iteration)
    {
        ++_swapCount;
    }

    public void GetStartTime(object sender, DateTime time)
    {
        _startDate = time;
    }

    public void GetFinishTime(object sender, DateTime time)
    {
        _finishTime = time;
    }

    public TimeSpan CalcDiffStartFinishTime() => _finishTime.Subtract(_startDate);
}

