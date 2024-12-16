using System;

namespace _20241201_HW_CsvFileOpener;

public abstract class ImportFile
{
    public abstract ScheduleListDataView Import(string fileName);
}

public class ImportBinary : ImportFile
{
    public override ScheduleListDataView Import(string fileName)
    {
        throw new NotImplementedException();
    }
}

public class ImportCSV : ImportFile
{
    public override ScheduleListDataView Import(string fileName)
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
                    scheduleList.groups.Add(new Group() {name = values[2]});
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

            return scheduleList;
        }
    }
}
