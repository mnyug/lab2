using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IContainerService
{
    AddResult AddExemplar(Exemplar exemplar, ContainerId containerId);
}