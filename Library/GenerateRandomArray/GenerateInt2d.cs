using System;

namespace GenerateRandomArray;

public class GenerateInt2d : GenerateArray
{
    private int[,] _intArray;

    public GenerateInt2d(int rows, int columns) : base(rows, columns)
    {
        Generate();
    }

    public int[,] GenArray
    {
        get => _intArray;
    }

    public override void Generate()
    {
        _intArray = new int[_rows, _columns];

        for (int i = 0; i < _intArray.GetLength(0); i++)
        {
            for (int k = 0; k < _intArray.GetLength(1); k++)
            {
                _intArray[i, k] = GetRandomInt();
            }
        }
    }
}
