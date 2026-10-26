using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IExpirationCondition
{
    bool IsSatisfied(Exemplar exemplar, DateTimeOffset now);
}