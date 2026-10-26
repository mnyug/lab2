using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ContainerService : IContainerService
{
    private readonly IRepository _repository;
    private readonly INeighborhoodService _neighborhoodService;

    public ContainerService(IRepository repository, INeighborhoodService neighborhoodService)
    {
        _neighborhoodService = neighborhoodService;
        _repository = repository;
    }

    public AddResult AddExemplar(Exemplar exemplar, ContainerId containerId)
    {
        IReadOnlyList<Exemplar> exemplars = _repository.GetExemplars(containerId);

        if (!_neighborhoodService.CanAdd(exemplar, exemplars))
        {
            return new AddResult.NeighborhoodNotAllowed();
        }

        if (!_repository.SaveExemplars(containerId, exemplar))
        {
            return new AddResult.ObxExceeded();
        }

        return new AddResult.Success(containerId);
    }
}