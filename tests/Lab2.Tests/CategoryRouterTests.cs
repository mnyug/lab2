using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab2.Tests.TestData;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CategoryRouterTests
{
    [Fact]
    public void DefaultRuleUsed()
    {
        // Arrange
        Container container = NewContainer(1);
        var defaultRule = new ContainerRule(container.ContainerId, Service([], container));
        var router = new CategoryRouter(new CategoryRuleMapping([], defaultRule));
        Exemplar bread = Item(1, Bakery);

        // Act
        AddResult result = router.Execute(bread);

        // Assert
        Assert.Equal(new AddResult.Success(container.ContainerId), result);
        Assert.Equal(bread, Assert.Single(container.Exemplars));
    }

    [Fact]
    public void MappingRoutesByCategory()
    {
        // Arrange
        Container electronicsContainer = NewContainer(1);
        Container fruitsContainer = NewContainer(2);
        ContainerService containerService = Service([], electronicsContainer, fruitsContainer);

        var mapping = new CategoryRuleMapping(
            [
                new RuleEntry(Electronics, new ContainerRule(electronicsContainer.ContainerId, containerService)),
                new RuleEntry(Fruits, new ContainerRule(fruitsContainer.ContainerId, containerService)),
            ],
            new StubRule(new AddResult.NoAvailableContainer()));

        var router = new CategoryRouter(mapping);
        Exemplar mouse = Item(1, Electronics);
        Exemplar apple = Item(2, Fruits);

        // Act
        router.Execute(mouse);
        router.Execute(apple);

        // Assert
        Assert.Equal(mouse, Assert.Single(electronicsContainer.Exemplars));
        Assert.Equal(apple, Assert.Single(fruitsContainer.Exemplars));
    }
}
