namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public readonly record struct ExpirationDate(DateTimeOffset Value)
{
    public bool IsExpiredAt(DateTimeOffset now)
    {
        return Value < now;
    }
}