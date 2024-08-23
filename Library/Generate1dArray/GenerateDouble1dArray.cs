namespace Generate1dArray;

public class GenerateDouble1dArray : Generate1dArray
{
    private int _numOfElements;
    private double[] _darray;

    public GenerateDouble1dArray(int num)
    {
        _numOfElements = num;
        Generate();
    }

    public double[] Darray
    {
        get => _darray;
    }

    protected override void Generate()
    {
        _darray = new double[_numOfElements];

        for (int i = 0; i < _darray.Length; i++)
        {
            _darray[i] = GetRandomDouble();
        }
    }
}
