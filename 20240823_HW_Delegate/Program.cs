using _20240823_HW_Delegate;
using GenerateRandomArray;

internal class Program
{
    private static void Main(string[] args)
    {
        GenerateDouble1d d1Gen = new GenerateDouble1d(10000);
        double[] d1 = (double[])d1Gen.GenArray.Clone();
        // PrintDoubleArray(d1);

        BubbleSort b1 = new BubbleSort(d1);
        b1.StartTime += PrintTime;
        b1.FinishTime += PrintTime;
        b1.RunSort();
        
        // PrintDoubleArray(b1.SortArray);

        InsertSort i1 = new InsertSort(d1);
        i1.StartTime += PrintTime;
        i1.FinishTime += PrintTime;
        i1.RunSort();
        // PrintDoubleArray(i1.SortArray);
        
        QuickSort q1 = new QuickSort(d1);
        q1.StartTime += PrintTime;
        q1.FinishTime += PrintTime;
        q1.RunSort();
        // PrintDoubleArray(q1.SortArray);
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
}