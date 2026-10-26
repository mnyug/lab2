using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface INeighborhoodService
{
    bool CanAdd(Exemplar exemplar, IReadOnlyList<Exemplar> exemplars);
}