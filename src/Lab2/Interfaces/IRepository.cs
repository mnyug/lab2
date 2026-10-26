using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IRepository
{
    IReadOnlyList<Exemplar> GetExemplars(ContainerId containerId);

    bool SaveExemplars(ContainerId containerId, Exemplar exemplar);
}