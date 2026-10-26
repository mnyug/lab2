using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Repository : IRepository
{
    private readonly Dictionary<ContainerId, Container> _data;

    public Repository(IReadOnlyList<Container> containers)
    {
        _data = containers.ToDictionary(container => container.ContainerId);
    }

    public IReadOnlyList<Exemplar> GetExemplars(ContainerId containerId)
    {
        return GetContainer(containerId).Exemplars;
    }

    public bool SaveExemplars(ContainerId containerId, Exemplar exemplar)
    {
        return GetContainer(containerId).TryAddExemplar(exemplar);
    }

    private Container GetContainer(ContainerId containerId)
    {
        if (!_data.TryGetValue(containerId, out Container? container))
        {
            throw new ArgumentException($"Тара {containerId.Id} не найдена", nameof(containerId));
        }

        return container;
    }
}
