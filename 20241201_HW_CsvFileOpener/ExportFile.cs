using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

public abstract class ExportFile
{
    public abstract bool Export(string fileName, List<Schedule> schedules);
}

public class ExportBinary : ExportFile
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

public class ExportCSV : ExportFile
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

public class ExportJson : ExportFile
{
    public override bool Export(string fileName, List<Schedule> schedules)
    {
        try
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {                
                StreamWriter sw = new StreamWriter(fs);
                string res = JsonSerializer.Serialize(schedules.Select(s => new {student = new {s.studentInfo.id,
                                                                                                                 s.studentInfo.firstName,
                                                                                                                 s.studentInfo.lastName, 
                                                                                                                 s.studentInfo.group.name},
                                                                                                  teacher = new {s.teacher.id,
                                                                                                                 s.teacher.firstName,
                                                                                                                 s.teacher.lastName},
                                                                                                  s.subject,
                                                                                                  s.room}));
                sw.Write(res);

                return true;
            }
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex);
            return false;
        }
    }

    public class ExportXML : ExportFile
    {
        public override bool Export(string fileName, List<Schedule> schedules)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Schedule>));

            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {                
                    serializer.Serialize(fs, schedules);

                    return true;
                }
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine(ex);
                return false;
            }
        }
    }
}
