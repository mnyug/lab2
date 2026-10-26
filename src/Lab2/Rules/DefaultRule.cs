using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class DefaultRule : IRule
{
    private readonly IRule _rule;

    public DefaultRule(IRule rule)
    {
        _rule = rule;
    }

    public AddResult Execute(Exemplar exemplar)
    {
        return _rule.Execute(exemplar);
    }
}