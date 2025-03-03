using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _20241226_HW_Threading.Handlers;
using _20241226_HW_Threading.Interfaces;
using _20241226_HW_Threading.Model;
using _20241226_HW_Threading.Services;
using GenerateRandomArray;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var timeTrackerSeq = new TimeTracker();
        GenerateDouble1d d1Gen = new GenerateDouble1d(100000);
        double[] d1 = (double[])d1Gen.GenArray.Clone();
        
        Console.Clear();

        // using (var logger = new Logger(string.Format($"{DateTime.Now.ToString("yyyyMMddTHHmmss")}_Sequence.log")))
        // {
        //     var bubbleSortSeq = new BubbleSort(d1, logger);
        //     var bubbleSortSeq1 = new BubbleSort(d1, logger);
        //     var quickSortSeq = new QuickSort(d1, logger);
        //     var insertSortSeq = new InsertSort(d1, logger);
        //     var loadingSeq = new Thread(() => LoadingService.Process(80));
    
            
        //     // loadingSeq.Start();
    
        //     System.Console.WriteLine("Sequence");
        //     timeTrackerSeq.On();
        //     bubbleSortSeq.Run();
        //     bubbleSortSeq1.Run();
        //     // quickSortSeq.Run();
        //     // insertSortSeq.Run();
    
        //     timeTrackerSeq.Off();
    
        //     // loadingSeq.Join();
        // }

        // using (var logger = new Logger(string.Format($"{DateTime.Now.ToString("yyyyMMddTHHmmss")}_Parallel.log")))
        // {
        //     // Thread loadingThreadSort = new Thread(() => LoadingService.Process(80));
            
        //     var timeTrackerPar = new TimeTracker();
    
        //     var bubbleSortTread = new BubbleSort(d1, logger);
        //     Thread bubbleThread = new Thread(bubbleSortTread.Run);

        //     var bubbleSortTread1 = new BubbleSort(d1, logger);
        //     Thread bubbleThread1 = new Thread(bubbleSortTread1.Run);
    
        //     var quickSortThread = new QuickSort(d1, logger);
        //     Thread quickThread = new Thread(quickSortThread.Run);
            
        //     var insertSortThread = new InsertSort(d1, logger);
        //     Thread insertThread = new Thread(insertSortThread.Run);

        //     //loadingThreadSort.Start();
        //     System.Console.WriteLine("Parallel");
            
        //     timeTrackerPar.On();
        //     // quickThread.Start();
        //     bubbleThread.Start();
        //     bubbleThread1.Start();
        //     // insertThread.Start();

        //     // quickThread.Join();
        //     bubbleThread.Join();
        //     bubbleThread1.Join();
        //     // insertThread.Join();

        //     timeTrackerPar.Off();
        // }

        {
            var bubbleSortSeq = new BubbleSort(d1);
            var bubbleSortSeq1 = new BubbleSort(d1);

            System.Console.WriteLine("Sequence");
            timeTrackerSeq.On();
            await bubbleSortSeq.Run();
            await bubbleSortSeq1.Run();

            timeTrackerSeq.Off();
        }

        {
            var timeTrackerPar = new TimeTracker();
    
            var bubbleSortTread = new BubbleSort(d1);
            var bubbleSortTread1 = new BubbleSort(d1);
            
            System.Console.WriteLine("Parallel");
            timeTrackerPar.On();

            

            var tasks = new List<Func<Task>>
            {
                bubbleSortTread.Run,
                bubbleSortTread1.Run
            };

            await Task.WhenAll(tasks.AsParallel().Select(async task => await task()));


            //loadingThreadSort.Start();

            timeTrackerPar.Off();

        }
    }
}