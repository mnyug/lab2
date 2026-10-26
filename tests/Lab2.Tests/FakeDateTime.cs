using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

internal sealed class FakeDateTime(DateTimeOffset now) : IDateTime
{
    public DateTimeOffset Now { get; set; } = now;
}
