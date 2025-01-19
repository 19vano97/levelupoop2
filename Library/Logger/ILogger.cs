using System;

namespace LoggerLibrary;

public interface ILogger
{
    public void Write(string message);
    public void Dispose();
}
