using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

public abstract class FileExport : FileController<Schedule>
{
    public override bool Export(string fileName, List<Schedule> list) => false;
}

public class ExportBinary : FileExport
{
    public override bool Export(string fileName, List<Schedule> schedules)
    {
        try
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                BinaryWriter bw = new BinaryWriter(fs);
    
                foreach (var schedule in schedules)
                {
                    bw.Write(schedule.ToString());
                }
            }

            return true;
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex);
            return false;
        }
    }
}

public abstract class ExportToTextFile : FileExport
{
}

public class ExportCSV : ExportToTextFile
{
    public override bool Export(string fileName, List<Schedule> schedules)
    {
        try
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                
                // TODO: add automatic header
                // sw.WriteLine("Student First Name;Student Last Name;Group Name;Teacher First Name;Teacher Last Name;Subject;Room");
    
                foreach (var schedule in schedules)
                {
                    sw.WriteLine(schedule);
                }
            }

            return true;
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex);
            return false;
        }
    }
}

public class ExportJson : ExportToTextFile
{
    public override bool Export(string fileName, List<Schedule> schedules)
    {
        try
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {                
                JsonSerializer.Serialize(fs, schedules);
            }

            return true;
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex);
            return false;
        }
    }

    public class ExportXML : ExportToTextFile
    {
        public override bool Export(string fileName, List<Schedule> schedules)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Schedule>));

            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {                
                    serializer.Serialize(fs, schedules);
                }

                return true;
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine(ex);
                return false;
            }
        }
    }
}
