using System;

namespace _20250110_HW_Multithreading_Barber;

public class Worker
{
    private Thread[] _threads;
    private Thread _producer;
    private SemaphoreSlim[] _queue;
    private SemaphoreSlim _producerSemaphore;
    private bool _IsWorking;
    private int _threadsCount;
    private object _m;

    public Worker(int threads = 10)
    {
        _threads = new Thread[threads];
        _producer = new Thread();
        _threadsCount = _threads.Length;
        _queue = new SemaphoreSlim[3];
        _producerSemaphore = new SemaphoreSlim(0);
        _m = new object();
        _IsWorking = false;

        for (var i = 0; i < _threadsCount; i++)
        {
            _queue[i] = new SemaphoreSlim(0);
        }
    }

    public void Run()
    {

    }

    private void WorkProducer()
    {
        lock (_m)
        {
            if (!_IsWorking)
            {
                _IsWorking = true;
                
            }
        }

        Thread.Sleep(1000);
    }

    private void OffsetQueue()
    {
        for (var i = 1; i <= _queue.Length; i++)
        {
            _queue[i - 1] = _queue[i];
        }

        _queue[_queue.Length - 1] = null;
    }
}
