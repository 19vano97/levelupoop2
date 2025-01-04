using System;
using System.Data.SqlTypes;
using _20241226_HW_Threading.Interfaces;

namespace _20241226_HW_Threading.Services;

public class Logger : ILogger, IDisposable
{
    private string _logFileName;
    private object _objSync = new object();
    private Stream _logOutStream;
    private TextWriter _logWriter;

    public Logger(string logFileName)
    {
        _logFileName = string.Format($"./Logs/{logFileName}");
        //_logOutStream = new FileStream(_logFileName, FileMode.Create);
        _logOutStream = new FileStream(_logFileName, FileMode.Append);
        _logWriter = new StreamWriter(_logOutStream);
    }

    public void Dispose()
    {
        if (_logOutStream != null)
        {
            _logWriter.Flush();
            _logOutStream.Dispose();
        }
    }

    public void Write(string message)
    {
        lock (_objSync)
        {
            _logWriter.Write(string.Format($"{DateTime.Now}: {message}\n"));
        }
    }
}
