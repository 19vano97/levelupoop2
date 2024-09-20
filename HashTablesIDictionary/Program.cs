using System.Collections;
using System.Collections.ObjectModel;

internal class Program
{
    private static void Main(string[] args)
    {
        Hashtable h1 = new Hashtable();

        h1.Add("One", "Value0");
        h1.Add("key1", "Value1");
        h1.Add("key2", "Value2");
        h1.Add("key3", "Value3");
        h1.Add("key4", "Value4");
        h1.Add("key5", "Value5");

        foreach (var item in h1)
        {
            System.Console.WriteLine(item.GetHashCode());
        }

        System.Console.WriteLine();

        foreach (DictionaryEntry item in h1)
        {
            System.Console.WriteLine(item);
        }

        foreach (var item in h1.Values)
        {
            System.Console.WriteLine(item);
        }
    }
}