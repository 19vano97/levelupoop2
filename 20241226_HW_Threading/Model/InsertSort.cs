using System;
using _20241226_HW_Threading.Interfaces;

namespace _20241226_HW_Threading.Model;

public class InsertSort : SortDoubleArray
{
    public InsertSort(double[] doubles, ILogger log) : base(doubles, log)
    {
    }

    public InsertSort(double[] doubles) : base(doubles)
    {
    }

    protected override void Sort()
    {
        int countExchange = 0;

        for (int i = 0; i < _doubles.Length; i++)
        {
            int insertIndex = i;
            double currentValue = _doubles[i];

            for (int y = i - 1; y >= 0; y--)
            {
                // _iterationEvent.Invoke(this, new Handlers.IterationEventArgs(countExchange));
                // countExchange++;

                if (_doubles[y] > currentValue)
                {
                    double temp = _doubles[y];
                    _doubles[y] = _doubles[y + 1];
                    _doubles[y + 1] = temp;
                    insertIndex = y;
                }
                else
                {
                    break;
                }
            }

            _doubles[insertIndex] = currentValue;
        }
    }
}
