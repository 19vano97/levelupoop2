using System;

namespace _20241226_HW_Threading.Views;

public class UI
{
    public void ShowDateTime(DateTime time, string message = null)
    {
        System.Console.WriteLine($"{message}{time.ToString("hh:mm:ss.ffffff")}");
    }

    public void ShowTime(TimeSpan time, string message = null)
    {
        System.Console.WriteLine($"{message}{time}");
    }

    public void ShowChar(char item)
    {
        System.Console.WriteLine(item);
    }
}
