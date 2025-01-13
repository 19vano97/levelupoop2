using System;

namespace _20250108_HW_Multithreading_SmokingPeople;

public class Worker : IDisposable
{
    private Thread[] _threads;
    private Thread _agentThread;
    private Ingredients[] _ingredients;
    private int _threadsCount;
    private bool _ingredientsOnTable;
    private object _m;
    private SemaphoreSlim _agent;
    private SemaphoreSlim[] _semaphores;

    public Worker()
    {
        _threads = new Thread[3];
        _agentThread = new Thread(Producer);
        _threadsCount = _threads.Length;
        _ingredients = new Ingredients[_threadsCount];
        _ingredientsOnTable = false;
        _agent = new SemaphoreSlim(0);
        _semaphores = new SemaphoreSlim[_threadsCount];
        _m = new object();

        for (var i = 0; i < _threadsCount; i++)
        {
            _semaphores[i] = new SemaphoreSlim(0);
        }
    }

    public void Run()
    {
        for (var i = 0; i < _threadsCount; i++)
        {
            int index = i;
            _threads[i] = new Thread(t => Consumer(index, (Ingredients)index));
        }

        _agentThread.Start();

        for (var i = 0; i < _threadsCount; i++)
        {
            _threads[i].Start();
        }

        Console.Read();

        Dispose();
    }

    private void Producer()
    {
        while (true)
        {
            lock (_m)
            {
                int[] randomIngredients = Choose();
                Place((Ingredients)randomIngredients[0], (Ingredients)randomIngredients[1]);
                int smokerIndex = 3 - (randomIngredients[0] + randomIngredients[1]);
                _semaphores[smokerIndex].Release();
            }

            _agent.Wait();
        }
    }

    private void Consumer(int index, Ingredients missedIngredient)
    {
        while (true)
        {
            _semaphores[index].Wait();

            lock (_m)
            {
                if (_ingredients != null && !Array.Exists(_ingredients, i => i == missedIngredient))
                {
                    System.Console.WriteLine($"Thread {index} is working!!!!");
                    _ingredients = null;
                    _ingredientsOnTable = false;
                    _agent.Release();
                }
            }

            Work(index);
        }
    }


    private int[] Choose()
    {
        int[] res = new int[2];
        res[0] = new Random().Next(0, _threadsCount);

        int newNumber = 0;

        do
        {
            newNumber = new Random().Next(0, _threadsCount);
        } while (newNumber == res[0]);

        res[1] = newNumber;

        return res;
    }

    private void Place(Ingredients ingredient1, Ingredients ingredient2)
    {
        lock (_m)
        {
            while (_ingredientsOnTable)
            {
                Monitor.Wait(_m);
            }

            _ingredients = new Ingredients[_threadsCount];
            _ingredients[0] = ingredient1;
            _ingredients[1] = ingredient2;
            _ingredientsOnTable = true;

            Console.WriteLine($"Agent placed: {ingredient1} and {ingredient2}");
            Monitor.PulseAll(_m); 
        }
    }

    private void Work(int index)
    {
        System.Console.WriteLine($"Thread {index} is active");
        Thread.Sleep(1000);
    }

    private void Signal()
    {
        for (var i = 0; i < _semaphores.Length; i++)
        {
            _semaphores[i].Release();
        }
    }

    public void Dispose()
    {
        _agentThread.Interrupt();

        for (var i = 0; i < _threadsCount; i++)
        {
            _threads[i].Interrupt();
        }
    }

    // private void Take(int index, Ingredients missingIngredient)
    // {
    //     lock (_m)
    //     {
    //         while (!_ingredientsOnTable || Array.Exists(_ingredients, i => i == missingIngredient))
    //         {
    //             Monitor.Wait(_m);
    //         }

    //         Console.WriteLine($"Smoker {index} takes ingredients and starts smoking");
    //         _ingredientsOnTable = false;

    //         Monitor.PulseAll(_m);
    //     }
    // }
}
