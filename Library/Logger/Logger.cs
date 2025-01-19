namespace LoggerLibrary;


public class Logger : ILogger, IDisposable
{
    private string _logFileName;
    private object _objSync = new object();
    private Stream _logOutStream;
    private TextWriter _logWriter;

    public Logger(string logFileName)
    {
        // #if DEBUG
        //     _logFileName = string.Format($"../../../Logs/{logFileName}");
        // #endif
        _logFileName = string.Format($"./Logs/{logFileName}.log");
        _logOutStream = new FileStream(_logFileName, FileMode.Create);
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
            _logWriter.Write(string.Format($"{DateTime.Now.ToString("yyyy-MM-dd’T’HH:mm:ss")}: {message}\n"));
        }
    }
}

