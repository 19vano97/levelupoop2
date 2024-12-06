using System;

namespace _20241201_HW_CsvFileOpener;

public class Student : Person
{
    public Group group;

    public Student(string fn, string ln) : base(fn, ln)
    {
    }
}
