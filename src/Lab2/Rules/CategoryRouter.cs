using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class CategoryRouter : IRule
{
    private readonly CategoryRuleMapping _mapping;

    public CategoryRouter(CategoryRuleMapping mapping)
    {
        _mapping = mapping;
    }

    public AddResult Execute(Exemplar exemplar)
    {
        return _mapping.GetRule(exemplar.Category).Execute(exemplar);
    }
}