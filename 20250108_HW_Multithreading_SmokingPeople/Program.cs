using _20250108_HW_Multithreading_SmokingPeople;

internal class Program
{
    private static void Main(string[] args)
    {
        var worker = new Worker();
        worker.Run();
    }
}