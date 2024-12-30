using System;
using System.Xml.Serialization;
using _20241226_HW_Threading.Model;
using _20241226_HW_Threading.Publisher;
using _20241226_HW_Threading.Views;

namespace _20241226_HW_Threading.Handlers;

public class MessageTimeHandler
{
    private UI _ui;

    public MessageTimeHandler(UI ui)
    {
        _ui = ui;
    }

    public void Subscribe(SortDoubleArray doubleArray)
    {
        doubleArray.StartTimePublisher += HandleTimeDisplay;
        doubleArray.EndTimePublisher += HandleTimeDisplay;
        doubleArray.DifferenceInTime += HandleTimeDisplay;
    }

    public void Subscribe(TimeTracker time)
    {
        time.startTimeEvent += HandleTimeDisplay;
        time.endTimeEvent += HandleTimeDisplay;
    }

    public void Unsubscribe(TimeTracker time)
    {
        time.startTimeEvent -= HandleTimeDisplay;
        time.endTimeEvent -= HandleTimeDisplay;
    }

    public void Unsubscribe(SortDoubleArray doubleArray)
    {
        doubleArray.StartTimePublisher -= HandleTimeDisplay;
        doubleArray.EndTimePublisher -= HandleTimeDisplay;
        doubleArray.DifferenceInTime -= HandleTimeDisplay;
    }

    private void HandleTimeDisplay(object? sender, IterationDateTimeEventArgs e)
    {
        _ui.ShowDateTime(e.Time, GetTypeToString(sender));
    }

    private void HandleTimeDisplay(object? sender, DifferenceInTimeEventArgs e)
    {
        _ui.ShowTime(e.FinishTime.Subtract(e.StartTime), GetTypeToString(sender));
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

