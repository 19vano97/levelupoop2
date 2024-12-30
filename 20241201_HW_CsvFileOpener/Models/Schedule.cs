using System;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

[XmlInclude(typeof(Student))]
[XmlInclude(typeof(Teacher))]
public class Schedule
{
    public Student studentInfo { get; set; }
    public Teacher teacher { get; set; }
    public string subject { get; set; }
    public int room { get; set; }

    public override string ToString()
    {
        return string.Format("{0};{1};{2};{3};{4};{5};{6}", 
                            studentInfo.firstName, studentInfo.lastName, studentInfo.group.name,
                            teacher.firstName, teacher.lastName, subject, room);
    }
}
