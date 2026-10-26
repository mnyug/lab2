using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

internal sealed class CountingLogger : ILogger
{
    public List<string> Messages { get; } = [];

    public void Log(string message)
    {
        Messages.Add(message);
    }
}
