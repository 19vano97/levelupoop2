using System;
using System.Text.Json.Serialization;
using RandomId;

namespace _20241201_HW_CsvFileOpener;

public class Person
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public ulong id { get; set; }

    public Person(string fn, string ln)
    {
        firstName = fn;
        lastName = ln;
        id = new RandomIdGenerator().GetRandomId();
    }

    [JsonConstructor]
    public Person(ulong id, string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
    }

    protected Person()
    {}
}
