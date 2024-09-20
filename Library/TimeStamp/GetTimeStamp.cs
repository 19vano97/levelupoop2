using System.Globalization;

namespace TimeStamp;

public class GetTimestamp
{
    public string UseTimeStamp(DateTime time) => DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
}
