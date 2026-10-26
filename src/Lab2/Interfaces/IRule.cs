using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IRule
{
    AddResult Execute(Exemplar exemplar);
}
