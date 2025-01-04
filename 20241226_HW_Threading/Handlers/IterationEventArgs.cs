using System;

namespace _20241226_HW_Threading.Handlers;

public class IterationEventArgs
{
    private int _iteration;

    public IterationEventArgs(int iteration)
    {
        _iteration = iteration;
    }

    public int Iteration
    {
        get => _iteration;
    }
}
