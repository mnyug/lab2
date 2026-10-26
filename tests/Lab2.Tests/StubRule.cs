using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

internal sealed class StubRule(AddResult result) : IRule
{
    public AddResult Execute(Exemplar exemplar)
    {
        return result;
    }
}
