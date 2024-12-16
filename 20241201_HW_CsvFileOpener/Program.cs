using _20241201_HW_CsvFileOpener;
using CountLinesInFile;
using static _20241201_HW_CsvFileOpener.ExportJson;

internal class Program
{
    public const string PATH = "./enhanced_students_data.csv";
    public const string PATH_DEBUG = "../../../enhanced_students_data.csv";

    private static void Main(string[] args)
    {
        var shcedule = new ImportCSV().Import(PATH);

        if (new ExportXML().Export("test.xml" ,shcedule.schedules))
        {
            System.Console.WriteLine("Ok");
        }
    }
}