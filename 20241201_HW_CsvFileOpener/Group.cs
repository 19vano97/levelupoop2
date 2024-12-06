using System;
using RandomId;

namespace _20241201_HW_CsvFileOpener;

public class Group
{
    public string name;
    public ulong id = new RandomIdGenerator().GetRandomId();
}
