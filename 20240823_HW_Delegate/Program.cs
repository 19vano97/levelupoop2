using System.Runtime.Intrinsics.Arm;
using _20240823_HW_Delegate;
using GenerateRandomArray;

internal class Program
{
    private static void Main(string[] args)
    {
        GenerateDouble1d d1Gen = new GenerateDouble1d(1000);
        double[] d1 = (double[])d1Gen.GenArray.Clone();
        
        BubbleSort b1 = new BubbleSort(d1);
        Subscriber sBubble = new Subscriber(b1);
        Thread bubble = new Thread(b1.RunSort);

        InsertSort i1 = new InsertSort(d1);
        Subscriber sInsert = new Subscriber(i1);
        Thread insertThread = new Thread(i1.RunSort);

        QuickSort q1 = new QuickSort(d1);
        Subscriber sQuick = new Subscriber(q1);
        Thread quickSortThread = new Thread(q1.RunSort);
        
        bubble.IsBackground = true;
        bubble.Start();
        
        insertThread.IsBackground = true;
        insertThread.Start();

        quickSortThread.IsBackground = true;
        quickSortThread.Start();

        PrintTimeDiff("Bubble", sBubble.CalcDiffStartFinishTime());
        System.Console.WriteLine("Bubble total exchanges: {0}", sBubble.ExchangeCount);
        System.Console.WriteLine("Bubble total swaps: {0}", sBubble.SwapCount);

        PrintTimeDiff("Insert", sInsert.CalcDiffStartFinishTime());
        System.Console.WriteLine("Insert total exchanges: {0}", sInsert.ExchangeCount);
        System.Console.WriteLine("Insert total swaps: {0}", sInsert.SwapCount);
        
        PrintTimeDiff("QuickSort", sQuick.CalcDiffStartFinishTime());
        System.Console.WriteLine("Quick total exchanges: {0}", sQuick.ExchangeCount);
        System.Console.WriteLine("Quick total swaps: {0}", sQuick.SwapCount);
    }

    public static void PrintDoubleArray(double[] darray)
    {
        for (int i = 0; i < darray.Length; i++)
        {
            System.Console.WriteLine(darray[i]);
        }

        System.Console.WriteLine();
    }

    public static void PrintTime(object sender, DateTime time)
    {
        System.Console.WriteLine("-------------------------");
        System.Console.WriteLine(time.ToString("hh:mm:ss.ffffff"));
        System.Console.WriteLine("-------------------------");
    }

    public static void PrintTime(string sortType, DateTime time)
    {
        System.Console.WriteLine("-------------------------");
        System.Console.WriteLine("{0}: {1}", sortType, time.ToString("hh:mm:ss.ffffff"));
        System.Console.WriteLine("-------------------------");
    }

    public static void PrintTimeDiff(string sortType, TimeSpan time)
    {
        System.Console.WriteLine("-------------------------");
        System.Console.WriteLine("{0}: {1}", sortType, time);
        System.Console.WriteLine("-------------------------");
    }
}