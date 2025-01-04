using System;
using _20241226_HW_Threading.Interfaces;

namespace _20241226_HW_Threading.Model;

public class QuickSort : SortDoubleArray
{
    public QuickSort(double[] doubles, ILogger log) : base(doubles, log)
    {
    }

    public QuickSort(double[] doubles) : base(doubles)
    {
    }

    protected override void Sort()
    {
        int countExchange = 0;
        QuickSortMehod(0, _doubles.Length - 1, countExchange);
    }

    private void QuickSortMehod(int low, int high, int countExchange)
    {
        if (low < high)
        {
            double pivot = _doubles[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (_doubles[j] <= pivot)
                {
                    i++;
                    double temp = _doubles[i];
                    _doubles[i] = _doubles[j];
                    _doubles[j] = temp;
                }

                // _iterationEvent.Invoke(this, new Handlers.IterationEventArgs(countExchange));
                // countExchange++;
            }

            double temp1 = _doubles[i + 1];
            _doubles[i + 1] = _doubles[high];
            _doubles[high] = temp1;
            int index = i + 1;
            
            QuickSortMehod(low, index - 1, countExchange);
            QuickSortMehod(index + 1, high, countExchange);
        }
    }
    
}
