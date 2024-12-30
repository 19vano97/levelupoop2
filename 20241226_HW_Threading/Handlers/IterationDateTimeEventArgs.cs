using System;
using _20241226_HW_Threading.Model;

namespace _20241226_HW_Threading.Publisher;

public class IterationDateTimeEventArgs
{
    private DateTime _time;

    public IterationDateTimeEventArgs(DateTime time)
    {
        _time = time;
    }

    public DateTime Time
    {
        get => _time;
    }
}
