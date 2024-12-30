using System;
using System.Text.Json.Serialization;

namespace _20241201_HW_CsvFileOpener;

public class Teacher : Person
{
    public Teacher(string fn, string ln) : base(fn, ln)
    {
    }

    [JsonConstructor]
    public Teacher(ulong id, string firstName, string lastName) : base(id, firstName, lastName)
    {
    }

    protected Teacher() : base()
    {}
}
