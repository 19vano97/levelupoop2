using _20241201_HW_CsvFileOpener;
using CountLinesInFile;

internal class Program
{
    public const string PATH = "./students.csv";

    private static void Main(string[] args)
    {
        // CountLinesInAFile count = new CountLinesInAFile(PATH);
        List<Student> students = new List<Student>();

        int count = 0;

        using (var reader = new StreamReader(@PATH))
        {
            while (reader.ReadLine() != null)
            {
                // if (count == 0)
                // {
                //     count++;
                //     continue;
                // }

                var lines = reader.ReadLine();
                var values = lines.Split(',', ';');
                
                students.Add(new Student() {firstName = values[0], lastName = values[1], age = int.Parse(values[2])});
                count++;
            }
        }

    }
}