using System.Security.Cryptography.X509Certificates;
using _20240823_Lesson_Publisher;

internal class Program
{
    private static void Main(string[] args)
    {
        PublisherEventArgs p1 = new PublisherEventArgs(5);

        SubscriberEventArgs s1 = new SubscriberEventArgs(p1);

        p1.Run();

        System.Console.WriteLine();
        System.Console.WriteLine("---------------------------------");
        System.Console.WriteLine();

        p1.NewIterationEvent += NewIterationStaticHandlerEventArgs;
        p1.Run();

        System.Console.WriteLine();
        System.Console.WriteLine("---------------------------------");
        System.Console.WriteLine();

        p1.NewIterationEvent += NewIterationStaticHandler2EventArgs;
        p1.Run();

        System.Console.WriteLine("Count: {0}", s1.AllIterationCount);
    }

    public static void NewIterationStaticHandler(int iteration)
    {
        System.Console.WriteLine("\t\t NewIterationStaticHandler({0})", iteration);
    }

    public static void NewIterationStaticHandler2(int iteration)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("\t\t NewIterationStaticHandler2({0})", iteration);
    }

    public static void NewIterationStaticHandlerEventArgs(object sender, NewiterationEventArgs args)
    {
        System.Console.WriteLine("\t\t NewIterationStaticHandler({0})", args.iteration);
    }

    public static void NewIterationStaticHandler2EventArgs(object sender, NewiterationEventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("\t\t NewIterationStaticHandler2({0})", args.iteration);
    }
}