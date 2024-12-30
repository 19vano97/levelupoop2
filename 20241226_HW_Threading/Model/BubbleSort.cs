using System;

namespace _20241226_HW_Threading.Model;

public class BubbleSort : SortDoubleArray
{
    public BubbleSort(double[] doubles) : base(doubles)
    {
    }

    protected override void Sort()
    {
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
            }
        }  
    }
}
