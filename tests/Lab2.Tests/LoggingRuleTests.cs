using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab2.Tests.TestData;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggingRuleTests
{
    [Fact]
    public void LogsSuccessAndFailure()
    {
        // Arrange
        var logger = new CountingLogger();
        var succeeding = new LoggingRule(new StubRule(new AddResult.Success(new ContainerId(1))), logger);
        var failing = new LoggingRule(new StubRule(new AddResult.ObxExceeded()), logger);
        Exemplar bread = Item(1, Bakery);

        // Act
        succeeding.Execute(bread);
        failing.Execute(bread);

        // Assert
        Assert.Equal(2, logger.Messages.Count);
        Assert.NotEqual(logger.Messages[0], logger.Messages[1]);
    }

    [Fact]
    public void ReturnsInnerResult()
    {
        // Arrange
        AddResult expected = new AddResult.NeighborhoodNotAllowed();
        var rule = new LoggingRule(new StubRule(expected), new CountingLogger());

        // Act
        AddResult result = rule.Execute(Item(1, Bakery));

        // Assert
        Assert.Same(expected, result);
    }
}
