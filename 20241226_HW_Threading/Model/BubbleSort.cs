using System;
using _20241226_HW_Threading.Interfaces;

namespace _20241226_HW_Threading.Model;

public class BubbleSort : SortDoubleArray
{
    public BubbleSort(double[] doubles, ILogger log) : base(doubles, log)
    {
    }

    public BubbleSort(double[] doubles) : base(doubles)
    {
    }

    protected override void Sort()
    {
        int countExchange = 0;
        for (int i = 0; i < _doubles.Length - 1; i++)
        {
            for (int k = 0; k < _doubles.Length - i - 1; k++)
            {   
                if (_doubles[k] > _doubles[k + 1])
                {
                    double temp = _doubles[k];
                    _doubles[k] = _doubles[k + 1];
                    _doubles[k + 1] = temp;
                }

                // _iterationEvent.Invoke(this, new Handlers.IterationEventArgs(countExchange));
                // countExchange++;
            }
        }  
    }
}
