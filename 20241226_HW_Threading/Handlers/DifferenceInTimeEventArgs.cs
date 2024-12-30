using System;

namespace _20241226_HW_Threading.Handlers;

public class DifferenceInTimeEventArgs
{
    private DateTime _startTime;
    private DateTime _finishTime;

    public DifferenceInTimeEventArgs(DateTime startTime, DateTime finishTime)
    {
        _startTime = startTime;
        _finishTime = finishTime;
    }

    public DateTime StartTime
    {
        get => _startTime;
    }

    public DateTime FinishTime
    {
        get => _finishTime;
    }
}
