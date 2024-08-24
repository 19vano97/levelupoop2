namespace GenerateRandomArray;

public abstract class GenerateArray
{
    protected int _numOfElements;
    protected int _rows;
    protected int _columns;

    public GenerateArray(int numOfElements)
    {
        _numOfElements = numOfElements;
    }

    public GenerateArray(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
    }

    public abstract void Generate();

    protected int GetRandomInt(int min = 0, int max = 100)
    {
        Random rnd = new Random();

        return rnd.Next(min, max);
    }
    protected double GetRandomDouble()
    {
        Random rnd = new Random();

        return rnd.NextDouble();
    }
}
