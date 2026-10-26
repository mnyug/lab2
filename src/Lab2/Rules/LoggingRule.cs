using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class LoggingRule : IRule
{
    private readonly IRule _rule;
    private readonly ILogger _logger;

    public LoggingRule(IRule rule, ILogger logger)
    {
        _rule = rule;
        _logger = logger;
    }

    public AddResult Execute(Exemplar exemplar)
    {
        AddResult result = _rule.Execute(exemplar);

        if (result is AddResult.Success)
        {
            _logger.Log($"Экземпляр {exemplar.Id} добавлен");
        }
        else
        {
            _logger.Log($"Экземпляр {exemplar.Id} не добавлен");
        }

        return result;
    }
}