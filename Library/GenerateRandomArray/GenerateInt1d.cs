using System;

namespace GenerateRandomArray;

public class GenerateInt1d : GenerateArray
{
    protected int[] _intArray;

    public GenerateInt1d(int numOfElements) : base(numOfElements)
    {
        Generate();
    }

    public int[] GenArray
    {
        get => _intArray;
    }

    public override void Generate()
    {
        _intArray = new int[_numOfElements];

        for (var i = 0; i < _intArray.Length; i++)
        {
            _intArray[i] = GetRandomInt();
        }
    }
}
