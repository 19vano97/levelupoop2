using System;

namespace _20241201_HW_CsvFileOpener;

public class ScheduleImport
{
    private string _path;
    private List<Student> _students = new List<Student>();
    private List<Teacher> _teachers = new List<Teacher>();
    private List<Group> _groups = new List<Group>();
    private List<Schedule> _schedules = new List<Schedule>();

    public ScheduleImport(string path)
    {
        _path = path;
    }

    public List<Schedule> Schedule
    {
        get => _schedules;
    }

    public void Import()
    {
        int count = 0;

        using (var reader = new StreamReader(_path))
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

                var groupToBeChecked = _groups.Where(g => g.name == values[2]).FirstOrDefault();
                var teacherToBeChecked = _teachers.Where(g => g.firstName == values[3] && g.lastName == values[4]).FirstOrDefault();
                var studentToBeChecked = _students.Where(g => g.firstName == values[0] && g.lastName == values[1]).FirstOrDefault();
                
                if (groupToBeChecked == null)
                {
                    _groups.Add(new Group() {name = values[2]});
                    groupToBeChecked = _groups.Where(g => g.name == values[2]).First();
                }
                
                if (teacherToBeChecked == null)
                {
                    _teachers.Add(new Teacher(values[3], values[4]));
                    teacherToBeChecked = _teachers.Where(t => t.firstName == values[3] && t.lastName == values[4]).First();
                }

                if (studentToBeChecked == null)
                {
                    _students.Add(new Student(values[0], values[1]) { group = groupToBeChecked });
                    studentToBeChecked = _students.Where(t => t.firstName == values[0] && t.lastName == values[1]).First();
                }

                _schedules.Add(new Schedule() {student = studentToBeChecked, teacher = teacherToBeChecked, subject = values[5], room = int.Parse(values[6]) });
            }
        }
    }
}
