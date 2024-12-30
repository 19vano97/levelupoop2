namespace RandomId;

public class RandomIdGenerator
{
    public ulong GetRandomId()
    {
        Random rnd = new Random();

        return (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (ulong)rnd.Next(0, int.MaxValue);
    }
}
