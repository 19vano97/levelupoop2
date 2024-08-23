using System;

namespace _20240823_Lesson_Publisher;

public class SubscriberEventArgs
{
    private int _allIterationCount;
    private PublisherEventArgs _p;

    public SubscriberEventArgs(PublisherEventArgs p)
    {
        _p = p;
        _p.NewIterationEvent += IterationCounterHandler;
    }

    public void Dispose()
    {
        _p.NewIterationEvent -= IterationCounterHandler;
    }

    public void IterationCounterHandler(object sender, NewiterationEventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        System.Console.WriteLine("\t\t\t NewIterationHandler({0})", args.iteration);
        ++_allIterationCount;
    }

    public int AllIterationCount
    {
        get => _allIterationCount;
    }
}
