using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class ContainerRule : IRule
{
    private readonly ContainerId _containerId;
    private readonly IContainerService _containerService;

    public ContainerRule(ContainerId containerId, IContainerService containerService)
    {
        _containerId = containerId;
        _containerService = containerService;
    }

    public AddResult Execute(Exemplar exemplar)
    {
        return _containerService.AddExemplar(exemplar, _containerId);
    }
}