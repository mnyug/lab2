using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CategoryRuleMapping
{
    private readonly Dictionary<Category, IRule> _rules;
    private readonly DefaultRule _defaultRule;

    public CategoryRuleMapping(IReadOnlyList<RuleEntry> entries, IRule defaultRule)
    {
        _rules = entries.ToDictionary(entry => entry.Category, entry => entry.Rule);
        _defaultRule = new DefaultRule(defaultRule);
    }

    public IRule GetRule(Category category)
    {
        return _rules.GetValueOrDefault(category, _defaultRule);
    }
}