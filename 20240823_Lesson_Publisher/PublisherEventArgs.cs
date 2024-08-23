using System;

namespace _20240823_Lesson_Publisher;

public class PublisherEventArgs
{
    const int DEFAULT_ITERATION_COUNT = 10;
    private int _iterationCount;
    private NewIterationDelegateEventArgs? _newIterationHandlers;

    // public void Subscribe(NewIterationDelegate handler)
    // {
    //     _newIterationHandlers += handler;
    // }
    
    // public void Unsubscribe(NewIterationDelegate handler)
    // {
    //     _newIterationHandlers -= handler;
    // }

    public event NewIterationDelegateEventArgs NewIterationEvent
    {
        add => _newIterationHandlers += value;
        remove => _newIterationHandlers -= value;
    }

    public PublisherEventArgs(int iterationCount = DEFAULT_ITERATION_COUNT)
    {
        _iterationCount = iterationCount;
    }

    public void Run()
    {
        for (int i = 0; i < _iterationCount; i++)
        {
            // _newIterationHandlers?.Invoke(i);
            _newIterationHandlers(this, new NewiterationEventArgs(i));
            System.Console.WriteLine("Run(), i = {0}", i);
        }
    }
}

