using System;

namespace _20241201_HW_CsvFileOpener;

public class Schedule
{
    public Student student;
    public Teacher teacher;
    public string subject;
    public int room;

    public override string ToString()
    {
        return string.Format("{0};{1};{2};{3};{4};{5};{6}", 
                            student.firstName, student.lastName, student.group.name,
                            teacher.firstName, teacher.lastName, subject, room);
    }
}
