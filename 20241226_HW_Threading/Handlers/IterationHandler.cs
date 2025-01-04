using System;
using _20241226_HW_Threading.Interfaces;
using _20241226_HW_Threading.Model;

namespace _20241226_HW_Threading.Handlers;

public class IterationHandler
{
    private ILogger _logger;

    public IterationHandler(ILogger logger)
    {
        _logger = logger;
    }

    public void Subscribe(SortDoubleArray doubleArray)
    {
        doubleArray.IterationEvent += HanderLoggerEvent;
    }

    public void Unsubscribe(SortDoubleArray doubleArray)
    {
        doubleArray.IterationEvent -= HanderLoggerEvent;
    }

    private void HanderLoggerEvent(object? sender, IterationEventArgs e)
    {
        _logger.Write(string.Format($"{GetTypeToString(sender)}. Iteration: {e.Iteration}"));
    }

    private string GetTypeToString(object sender)
    {
        if (sender is BubbleSort)
            return "Bubble sort";
        else if (sender is InsertSort)
            return "Insert sort";
        else if (sender is QuickSort)
            return "Quick sort";
        else
            return null;
    }
}
