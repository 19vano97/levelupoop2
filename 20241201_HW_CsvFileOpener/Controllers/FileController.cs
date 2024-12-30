using System;

namespace _20241201_HW_CsvFileOpener;

public abstract class FileController<T>
{
    public virtual List<T> Open() => null;

    public virtual bool Save() => false;

    public virtual List<T> Import(string fileName) => null;

    public virtual bool Export(string fileName, List<T> list) => false;

}
