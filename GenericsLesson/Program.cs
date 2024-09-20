using GenericsLesson;

internal class Program
{
    private static void Main(string[] args)
    {
        QueueGeneric<int> q = new QueueGeneric<int>();

        q.EnQueue(21);

        System.Console.WriteLine(q.DeQueue());
    }
}