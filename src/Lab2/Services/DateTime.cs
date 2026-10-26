using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class DateTime : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}