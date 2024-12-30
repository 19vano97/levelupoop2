using System.Runtime.CompilerServices;
using _20241226_HW_Threading.Handlers;
using _20241226_HW_Threading.Model;
using _20241226_HW_Threading.Services;
using GenerateRandomArray;

internal class Program
{
    private static void Main(string[] args)
    {
        var timeTrackerSeq = new TimeTracker();
        GenerateDouble1d d1Gen = new GenerateDouble1d(100000);
        double[] d1 = (double[])d1Gen.GenArray.Clone();
        
        Console.Clear();

        var bubbleSortSeq = new BubbleSort(d1);
        var quickSortSeq = new QuickSort(d1);
        var insertSortSeq = new InsertSort(d1);
        var loadingSeq = new Thread(() => Loading.Process(80));

        
        //loadingSeq.Start();

        System.Console.WriteLine("Sequence");
        timeTrackerSeq.On();
        bubbleSortSeq.Run();
        quickSortSeq.Run();
        insertSortSeq.Run();

        timeTrackerSeq.Off();

        //loadingSeq.Join();


        Thread loadingThreadSort = new Thread(() => Loading.Process(80));
        
        var timeTrackerPar = new TimeTracker();

        var bubbleSortTread = new BubbleSort(d1);
        Thread bubbleThread = new Thread(bubbleSortTread.Run);

        var quickSortThread = new QuickSort(d1);
        Thread quickThread = new Thread(quickSortThread.Run);
        
        var insertSortThread = new InsertSort(d1);
        Thread insertThread = new Thread(insertSortThread.Run);

        
        
        //loadingThreadSort.Start();
        System.Console.WriteLine("Parallel");
        
        timeTrackerPar.On();
        quickThread.Start();
        bubbleThread.Start();
        insertThread.Start();

        quickThread.Join();
        bubbleThread.Join();
        insertThread.Join();

        timeTrackerPar.Off();
    }
}