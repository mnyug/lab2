using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Expiration;

public class ExpiredCondition : IExpirationCondition
{
    public bool IsSatisfied(Exemplar exemplar, DateTimeOffset now)
    {
        return exemplar.IsExpiredAt(now);
    }
}