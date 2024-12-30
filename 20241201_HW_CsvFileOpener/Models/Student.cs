using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace _20241201_HW_CsvFileOpener;

[XmlInclude(typeof(Group))]
public class Student : Person
{
    public Group group { get; set; }

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    [JsonConstructor]
    public Student(ulong id, string firstName, string lastName, Group group) : base(id, firstName, lastName)
    {
        this.group = group;
    }

    protected Student() : base()
    {}
}
