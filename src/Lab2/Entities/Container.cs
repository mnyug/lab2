using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Container
{
    private readonly List<Exemplar> _exemplars = [];

    public Container(Obx maxObx, ContainerId containerId)
    {
        ContainerId = containerId;
        MaxObx = maxObx;
    }

    public ContainerId ContainerId { get; }

    public Obx MaxObx { get; }

    public IReadOnlyList<Exemplar> Exemplars => _exemplars.AsReadOnly();

    public bool TryAddExemplar(Exemplar exemplar)
    {
        if (!CanFit(exemplar))
        {
            return false;
        }

        _exemplars.Add(exemplar);

        return true;
    }

    private bool CanFit(Exemplar exemplar)
    {
        Obx total = _exemplars.Aggregate(Obx.Zero, (sum, exemp) => sum + exemp.Sku.Weight);

        return total + exemplar.Sku.Weight <= MaxObx;
    }
}