using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class ExpirationDateRule(IRule rule, IExpirationCondition expirationCondition, IDateTime clock) : IRule
{
    public AddResult Execute(Exemplar exemplar)
    {
        return !expirationCondition.IsSatisfied(exemplar, clock.Now) ? new AddResult.ExpirationNotAllowed() : rule.Execute(exemplar);
    }
}