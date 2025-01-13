using System;

namespace _20250107_HW_Ph_Lunch;

public class Worker
{
    private Thread[] _threads;

    private object _m;

    private int _threadsCount;
    private SemaphoreSlim[] _semaphores;
    private Statuses[] _states;

    public Worker(int countOfThreads = 5)
    {
        _threads = new Thread[countOfThreads];
        _threadsCount = _threads.Length;
        _m = new object();
        _semaphores = new SemaphoreSlim[countOfThreads];
        _states = new Statuses[countOfThreads];
        
        for (var i = 0; i < _threadsCount; i++)
        {
            _semaphores[i] = new SemaphoreSlim(0);
            _states[i] = Statuses.Idle;
        }
    }

    public void Run()
    {
        for (var i = 0; i < _threadsCount; i++)
        {
            int index = i;
            _threads[i] = new Thread(() => ThreadRun(index));
        }

        foreach (var item in _threads)
        {
            item.Start();
        }

        Console.Read();

        foreach (var item in _threads)
        {
            item.Interrupt();
        }
    }

    private void ThreadRun(int index)
    {
        while (true)
        {
            Idle(index);
            Take(index);
            Active(index);
            Put(index);
        }
    }

    private void Take(int index)
    {
        lock (_m)
        {
            _states[index] = Statuses.Waiting;
            Test(index);
        }

        _semaphores[index].Wait();
    }

    private void Put(int index)
    {
        lock (_m)
        {
            _states[index] = Statuses.Idle;
            Test(Left(index));
            Test(Right(index));
        }
    }

    private void Test(int index)
    {
        if (_states[index] == Statuses.Waiting && _states[Left(index)] != Statuses.Active
                                               && _states[Right(index)] != Statuses.Active)
        {
            _states[index] = Statuses.Active;
            _semaphores[index].Release();
        }
    }

    private int Left(int index)
    {
        return (index - 1 + _threadsCount) % _threadsCount;
    }

    private int Right(int index)
    {
        return (index + 1) % _threadsCount;
    }

    private void Idle(int index)
    {
        System.Console.WriteLine($"Thread #{index} is idling");
        Thread.Sleep(1000);
    }

    private void Active(int index)
    {
        System.Console.WriteLine($"Thread #{index} is active");
        Thread.Sleep(1000);
    }
}
