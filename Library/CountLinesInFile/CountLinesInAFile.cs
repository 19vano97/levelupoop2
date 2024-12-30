namespace CountLinesInFile;

public class CountLinesInAFile
{
    private string _path;
    private ulong  _count;

    public CountLinesInAFile(string path)
    {
        _path = path;
        CountLines();
    }

    public ulong Count
    {
        get => _count;
    }

    private void CountLines()
    {   _count = 0;

        using(var reader = new StreamReader(@_path))
        {
            while (reader.ReadLine() != null)
            {
                _count++;
            }
        }
    }


}
