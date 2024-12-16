using System;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

[XmlInclude(typeof(Group))]
public class Student : Person
{
    public Group group;

    public Student(string fn, string ln) : base(fn, ln)
    {
    }

    public Student() : base()
    {}
}
