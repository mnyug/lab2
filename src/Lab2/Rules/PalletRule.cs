using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class PalletRule : IRule
{
    private readonly IReadOnlyList<IRule> _containerRules;

    public PalletRule(IReadOnlyList<IRule> containerRules)
    {
        _containerRules = [.. containerRules];
    }

    public AddResult Execute(Exemplar exemplar)
    {
        foreach (IRule rule in _containerRules)
        {
            AddResult result = rule.Execute(exemplar);
            if (result is AddResult.Success)
            {
                return result;
            }
        }

        return new AddResult.NoAvailableContainer();
    }
}