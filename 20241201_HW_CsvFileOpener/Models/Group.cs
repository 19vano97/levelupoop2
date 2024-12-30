using System;
using System.Text.Json.Serialization;
using RandomId;

namespace _20241201_HW_CsvFileOpener;

public class Group
{
    public string name { get; set; }
    public ulong id { get; set; }

    public Group(string groupName)
    {
        name = groupName;
        id = new RandomIdGenerator().GetRandomId();
    }

    [JsonConstructor]
    public Group(ulong id, string name)
    {
        this.name = name;
        this.id = id;
    }

    protected Group()
    {}
}
