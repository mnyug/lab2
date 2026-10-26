namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class ProductGroup
{
    private readonly Groups _mapping;

    public ProductGroup(Groups mapping)
    {
        _mapping = mapping;
    }

    public GroupId? GetGroup(Exemplar exemplar)
    {
        return _mapping.GetGroup(exemplar.Category);
    }
}