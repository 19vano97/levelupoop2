using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

public abstract class FileImport : FileController<Schedule>
{
    public override List<Schedule> Import(string fileName) => null;
}

public abstract class ImportTextFile : FileImport
{
}

public class ImportBinary : FileImport
{
    public override List<Schedule> Import(string fileName)
    {
        throw new NotImplementedException();
    }
}

public class ImportCSV : ImportTextFile
{
    public override List<Schedule> Import(string fileName)
    {
        ScheduleListDataView scheduleList = new ScheduleListDataView();
        int count = 0;

        using (var reader = new StreamReader(fileName))
        {
            while (reader.ReadLine() != null)
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }

                var lines = reader.ReadLine();
                var values = lines.Split(',', ';');

                var groupToBeChecked = scheduleList.groups.Where(g => g.name == values[2]).FirstOrDefault();
                var teacherToBeChecked = scheduleList.teachers.Where(g => g.firstName == values[3] && g.lastName == values[4]).FirstOrDefault();
                var studentToBeChecked = scheduleList.students.Where(g => g.firstName == values[0] && g.lastName == values[1]).FirstOrDefault();
                
                if (groupToBeChecked == null)
                {
                    scheduleList.groups.Add(new Group(values[2]));
                    groupToBeChecked = scheduleList.groups.Where(g => g.name == values[2]).First();
                }
                
                if (teacherToBeChecked == null)
                {
                    scheduleList.teachers.Add(new Teacher(values[3], values[4]));
                    teacherToBeChecked = scheduleList.teachers.Where(t => t.firstName == values[3] && t.lastName == values[4]).First();
                }

                if (studentToBeChecked == null)
                {
                    scheduleList.students.Add(new Student(values[0], values[1]) { group = groupToBeChecked });
                    studentToBeChecked = scheduleList.students.Where(t => t.firstName == values[0] && t.lastName == values[1]).First();
                }

                scheduleList.schedules.Add(new Schedule() {studentInfo = studentToBeChecked, teacher = teacherToBeChecked, subject = values[5], room = int.Parse(values[6]) });
            }

            return scheduleList.schedules;
        }
    }

    public class ImportJson : ImportTextFile
    {
        public override List<Schedule> Import(string data)
        {
            return JsonSerializer.Deserialize<List<Schedule>>(data, new JsonSerializerOptions {IncludeFields = true});
        }
    }

    public class ImportXml : ImportTextFile
    {
        public override List<Schedule> Import(string fileName)
        {
            List<Schedule> schedules = new List<Schedule>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Schedule>));

            using (var reader = XmlReader.Create(fileName))
            {
                schedules = (List<Schedule>)serializer.Deserialize(reader);
            }

            return schedules;
        }
    }
}
