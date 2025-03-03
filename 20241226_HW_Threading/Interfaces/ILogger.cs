using System;

namespace _20241226_HW_Threading.Interfaces;

public interface ILogger
{
    public Task Write(string message);
}
