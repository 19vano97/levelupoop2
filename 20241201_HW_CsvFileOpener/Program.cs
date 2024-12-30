using _20241201_HW_CsvFileOpener;
using CountLinesInFile;
using static _20241201_HW_CsvFileOpener.ExportJson;
using static _20241201_HW_CsvFileOpener.ImportCSV;

internal class Program
{
    public const string PATH = "./enhanced_students_data.csv";
    public const string PATH_DEBUG = "../../../enhanced_students_data.csv";
    public const string PATH_JSON = "./test.json";
    public const string PATH_JSON_DEBUG = "../../../test.json";
    public const string PATH_XML = "./test.xml";
    public const string PATH_XML_DEBUG = "../../../test.xml";
    
    private static void Main(string[] args)
    {
        var scheduleJson = new ImportJson().Import(File.ReadAllText(PATH_JSON_DEBUG));
        var scheduleXml = new ImportXml().Import(PATH_XML_DEBUG);

        // if (new ExportJson().Export("test.json" ,schedule.schedules))
        // {
        //     System.Console.WriteLine("Ok");
        // }
    }
}