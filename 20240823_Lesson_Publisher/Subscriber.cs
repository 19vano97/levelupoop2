using System;

namespace _20240823_Lesson_Publisher;

public class Subscriber : IDisposable
{
    private int _allIterationCount;
    private PublisherEvent _p;

    public Subscriber(PublisherEvent p)
    {
        _p = p;
        _p.NewIterationEvent += IterationCounterHandler;
    }

    public void Dispose()
    {
        _p.NewIterationEvent -= IterationCounterHandler;
    }

    public void IterationCounterHandler(int iteration)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        System.Console.WriteLine("\t\t\t NewIterationHandler({0})", iteration);
        ++_allIterationCount;
    }

    public int AllIterationCount
    {
        get => _allIterationCount;
    }
}
