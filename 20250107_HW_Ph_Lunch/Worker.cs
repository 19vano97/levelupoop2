using System;
using System.Threading.Tasks;
using LoggerLibrary;

namespace _20250107_HW_Ph_Lunch;

public class Worker
{
    private Thread[] _threads;
    private ILogger _logger;
    private object _m;
    private Mutex[] _mutexs;
    private Dictionary<int, bool> _ownedCreated;
    private int _threadsCount;
    //private SemaphoreSlim[] _semaphores;
    private Statuses[] _states;

    public Worker(int countOfThreads = 5)
    {
        _threads = new Thread[countOfThreads];
        _threadsCount = _threads.Length;
        string fileName = DateTime.Now.ToString("yyyy-MM-dd’T’HH:mm:ss");
        _logger = new Logger($"log_{fileName}");
        _m = new object();
        _ownedCreated = new Dictionary<int, bool>();
        _mutexs = new Mutex[_threadsCount];
        // _semaphores = new SemaphoreSlim[countOfThreads];
        _states = new Statuses[countOfThreads];
        
        // for (var i = 0; i < _threadsCount; i++)
        // {
        //     _semaphores[i] = new SemaphoreSlim(0);
        //     _states[i] = Statuses.Idle;
        // }
    }

    #region semaphore
        // public void Run()
        // {
        //     for (var i = 0; i < _threadsCount; i++)
        //     {
        //         int index = i;
        //         _threads[i] = new Thread(() => ThreadRun(index));
        //     }
    
        //     foreach (var item in _threads)
        //     {
        //         item.Start();
        //     }
    
        //     Console.Read();
    
        //     foreach (var item in _threads)
        //     {
        //         item.Interrupt();
        //     }
        // }
    
        // private void ThreadRun(int index)
        // {
        //     while (true)
        //     {
        //         Idle(index);
        //         Take(index);
        //         Active(index);
        //         Put(index);
        //     }
        // }
    
        // private void Take(int index)
        // {
        //     lock (_m)
        //     {
        //         _states[index] = Statuses.Waiting;
        //         Test(index);
        //     }
    
        //     _semaphores[index].Wait();
        // }
    
        // private void Take(int index)
        // {
        //     lock (_m)
        //     {
        //         _states[index] = Statuses.Waiting;
        //         Test(index);
        //     }
    
        //     _semaphores[index].Wait();
        // }
    
        // private void Put(int index)
        // {
        //     lock (_m)
        //     {
        //         _states[index] = Statuses.Idle;
        //         Test(Left(index));
        //         Test(Right(index));
        //     }
        // }
    
        // private void Test(int index)
        // {
        //     if (_states[index] == Statuses.Waiting && _states[Left(index)] != Statuses.Active
        //                                            && _states[Right(index)] != Statuses.Active)
        //     {
        //         _states[index] = Statuses.Active;
        //         _semaphores[index].Release();
        //     }
        // }
    
        // private int Left(int index)
        // {
        //     return (index - 1 + _threadsCount) % _threadsCount;
        // }
    
        // private int Right(int index)
        // {
        //     return (index + 1) % _threadsCount;
        // }
    
        // private void Idle(int index)
        // {
        //     System.Console.WriteLine($"Thread #{index} is idling");
        //     Thread.Sleep(1000);
        // }
    
        // private void Active(int index)
        // {
        //     System.Console.WriteLine($"Thread #{index} is active");
        //     Thread.Sleep(1000);
        // }
    #endregion

    #region Mutex
        public void Run()
        {
            for (var i = 0; i < _threadsCount; i++)
            {
                _mutexs[i] = new Mutex();
                _ownedCreated[i] = false;
            }

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

            _logger.Dispose();
        }
    
        private async Task ThreadRun(int index)
        {
            while (true)
            {
                Idle(index);
                await Take(index);
                Active(index);
                await Put(index);
            }
        }
    
        private async Task Take(int index)
        {
            lock (_m)
            {
                _states[index] = Statuses.Waiting;
                PrintStatus(index);
                Test(index);
            }
        }
    
        private async Task Put(int index)
        {
            // if (_states[index] == Statuses.Active && _ownedCreated[index])
            // {
            //     try
            //     {
            //         _mutexs[index].ReleaseMutex();
            //         ReleaseThread(index);
            //         _ownedCreated[index] = false;
            //     }
            //     catch (System.ApplicationException ex)
            //     {
            //         System.Console.WriteLine($"Release thread: {index}");
            //         System.Console.WriteLine(ex);
            //         ReleaseThread(index);
            //     }
            // }
            // else
            // {
            //     ReleaseThread(index);
            // }

            lock (_m)
            {
                _states[index] = Statuses.Idle;
                Test(Left(index));
                Test(Right(index));
                PrintStatus(index);
            }
        }
    
        private async Task Test(int index)
        {
            if (_states[index] == Statuses.Waiting && _states[Left(index)] != Statuses.Active
                                                   && _states[Right(index)] != Statuses.Active)
            {
                _states[index] = Statuses.Active;
                PrintStatus(index);
                _mutexs[index].WaitOne();
                _ownedCreated[index] = true;
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
            // PrintStatus(index);
            Thread.Sleep(1000);
        }
    
        private void Active(int index)
        {
            Thread.Sleep(1000);
        }

        private void PrintStatus(int index)
        {
            _logger.Write($"Thread {index} Status: {_states[index]}");
            System.Console.WriteLine($"Thread {index} Status: {_states[index]}");
        }

        private void ReleaseThread(int index)
        {
            _logger.Write($"Thread {index} tried to release a mutex it doesn't own.");
            System.Console.WriteLine($"Thread {index} tried to release a mutex it doesn't own.");
        }

        private void CheckMutex(int index)
        {
            if (!_ownedCreated[index])
            {
                _mutexs[index] = Mutex.OpenExisting(index.ToString());
            }
        }
    #endregion
}
