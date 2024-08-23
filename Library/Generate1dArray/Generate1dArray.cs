using System;

namespace Generate1dArray;

public abstract class Generate1dArray
{
    public Generate1dArray()
    {
        
    }

    protected abstract void Generate();

    protected double GetRandomDouble()
    {
        Random rnd = new Random();

        return rnd.NextDouble();
    }
}
