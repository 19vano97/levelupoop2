using System;

namespace GenerateRandomArray;

public class GenerateDouble2d : GenerateArray
{
    private double[,] _darray;

    public GenerateDouble2d(int rows, int columns) : base(rows, columns)
    {
        Generate();
    }

    public double[,] GenArray
    {
        get => _darray;
    }

    public override void Generate()
    {
        _darray = new double[_rows, _columns];

        for (int i = 0; i < _darray.GetLength(0); i++)
        {
            for (int k = 0; k < _darray.GetLength(1); k++)
            {
                _darray[i, k] = GetRandomDouble();
            }
        }
    }
}
