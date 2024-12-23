using System;

namespace _20241201_HW_CsvFileOpener;

public class FileController
{
    public string pathToFile {get; set;}

    public virtual List<Schedule> Open() => null;

    public virtual bool Save() => false;

    public virtual List<Schedule> Import(string fileName) => null;

    public virtual bool Export(string fileName, List<Schedule> schedules) => false;
}
