using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

public class ScheduleListDataView
{
    public List<Student> students = new List<Student>();
    public List<Teacher> teachers = new List<Teacher>();
    public List<Group> groups = new List<Group>();
    public List<Schedule> schedules = new List<Schedule>();
}
