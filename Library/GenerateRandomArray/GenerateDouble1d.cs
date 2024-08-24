using System;

namespace GenerateRandomArray;

public class GenerateDouble1d : GenerateArray
{
    private double[] _darray;

    public GenerateDouble1d(int numOfElements) : base(numOfElements)
    {
        Generate();
    }

    public double[] GenArray
    {
        get => _darray;
    }

    public override void Generate()
    {
        _darray = new double[_numOfElements];

        for (var i = 0; i < _darray.Length; i++)
        {
            _darray[i] = GetRandomDouble();
        }
    }
}
