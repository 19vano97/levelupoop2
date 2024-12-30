using System;

namespace _20241226_HW_Threading.Services;

public static class Loading
{
    public static void Process(object data, int speedLoader = 500)
    {
        Thread.Sleep(10);

        int iterationCount = (int)data;
        char[] loader = new char[] {'/', '-', '\\', '|', };

         for (var i = 0; i < iterationCount; i++)
         {
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            int pos = i % loader.Length;

            Console.SetCursorPosition(x, y - 1);
            System.Console.Write(' ');
            Console.SetCursorPosition(x, y);
            System.Console.Write(loader[pos]);
            Console.SetCursorPosition(0, x);

            Thread.Sleep(speedLoader);
         }
    }
}
