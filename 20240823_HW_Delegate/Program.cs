using _20240823_HW_Delegate;
using Generate1dArray;

internal class Program
{
    private static void Main(string[] args)
    {
        GenerateDouble1dArray d1Gen = new GenerateDouble1dArray(7);
        double[] d1 = (double[])d1Gen.Darray.Clone();
        PrintDoubleArray(d1);

        BubbleSort b1 = new BubbleSort(d1);
        b1.Sort();
        PrintDoubleArray(b1.SortArray);

        InsertSort i1 = new InsertSort(d1);
        i1.Sort();
        PrintDoubleArray(i1.SortArray);
        
        QuickSort q1 = new QuickSort(d1);
        q1.Sort();
        PrintDoubleArray(q1.SortArray);


    }

    public static void PrintDoubleArray(double[] darray)
    {
        for (int i = 0; i < darray.Length; i++)
        {
            System.Console.WriteLine(darray[i]);
        }

        System.Console.WriteLine();
    }
}