using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class NeighborhoodService : INeighborhoodService
{
    private readonly ProductGroup _productGroup;

    public NeighborhoodService(ProductGroup productGroup)
    {
        _productGroup = productGroup;
    }

    public bool CanAdd(Exemplar exemplar, IReadOnlyList<Exemplar> exemplars)
    {
        GroupId? newGroup = _productGroup.GetGroup(exemplar);

        return exemplars.Select(exemp => _productGroup.GetGroup(exemp)).All(existingGroup => existingGroup == newGroup);
    }
}