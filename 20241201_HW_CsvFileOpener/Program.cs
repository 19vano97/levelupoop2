using _20241201_HW_CsvFileOpener;
using CountLinesInFile;

internal class Program
{
    public const string PATH = "./enhanced_students_data.csv";
    public const string PATH_DEBUG = "../../../enhanced_students_data.csv";

    private static void Main(string[] args)
    {
        ScheduleImport sc  = new ScheduleImport(PATH);  

        sc.Import();      

        ScheduleExport csvSchedule = new ScheduleExport("test", "csv", sc.Schedule);
        ScheduleExport binSchedule = new ScheduleExport("test", "bin", sc.Schedule);

        csvSchedule.Export();
        binSchedule.Export();

        long initFileSize = new FileInfo(PATH).Length;
        long binFileSize = new FileInfo(binSchedule.fileName).Length;
        long csvOutputFileSize = new FileInfo(csvSchedule.fileName).Length;

        System.Console.WriteLine(initFileSize);
        System.Console.WriteLine(binFileSize);
        System.Console.WriteLine(csvOutputFileSize);
    }
}