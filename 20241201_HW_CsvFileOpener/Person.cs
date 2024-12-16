using System;
using RandomId;

namespace _20241201_HW_CsvFileOpener;

public class Person
{
    public string firstName;
    public string lastName;
    public ulong id = new RandomIdGenerator().GetRandomId();

    public Person(string fn, string ln)
    {
        firstName = fn;
        lastName = ln;
    }

    public Person()
    {}
}
