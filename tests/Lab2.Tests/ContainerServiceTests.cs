using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab2.Tests.TestData;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ContainerServiceTests
{
    [Fact]
    public void PaperAndScissorsNotAllowed()
    {
        // Arrange
        Container container = NewContainer(1);
        container.TryAddExemplar(Item(1, Paper));

        ContainerService containerService = Service(
            [
                new GroupEntry(Paper, new GroupId(1)),
                new GroupEntry(Scissors, new GroupId(2)),
                new GroupEntry(Stones, new GroupId(3)),
            ],
            container);

        // Act
        AddResult result = containerService.AddExemplar(Item(2, Scissors), container.ContainerId);

        // Assert
        Assert.IsType<AddResult.NeighborhoodNotAllowed>(result);
        Assert.Single(container.Exemplars);
    }

    [Fact]
    public void NoGroupAfterGroupNotAllowed()
    {
        // Arrange
        Container container = NewContainer(1);
        container.TryAddExemplar(Item(1, Paper));

        ContainerService containerService = Service([new GroupEntry(Paper, new GroupId(1))], container);

        // Act
        AddResult result = containerService.AddExemplar(Item(2, Bakery), container.ContainerId);

        // Assert
        Assert.IsType<AddResult.NeighborhoodNotAllowed>(result);
        Assert.Single(container.Exemplars);
    }

    [Fact]
    public void NoGroupAfterNoGroupAllowed()
    {
        // Arrange
        Container container = NewContainer(1);
        container.TryAddExemplar(Item(1, Bakery));

        ContainerService containerService = Service([], container);

        // Act
        AddResult result = containerService.AddExemplar(Item(2, Fruits), container.ContainerId);

        // Assert
        Assert.IsType<AddResult.Success>(result);
        Assert.Equal(2, container.Exemplars.Count);
    }

    [Fact]
    public void SameCategoryTwiceAllowed()
    {
        // Arrange
        Container container = NewContainer(1);
        ContainerService containerService = Service([new GroupEntry(Paper, new GroupId(1))], container);

        containerService.AddExemplar(Item(1, Paper), container.ContainerId);

        // Act
        AddResult result = containerService.AddExemplar(Item(2, Paper), container.ContainerId);

        // Assert
        Assert.IsType<AddResult.Success>(result);
        Assert.Equal(2, container.Exemplars.Count);
    }

    [Fact]
    public void ObxExceeded()
    {
        // Arrange
        Container container = NewContainer(1, maxObx: 1);
        container.TryAddExemplar(Item(1, Bakery));

        ContainerService containerService = Service([], container);

        // Act
        AddResult result = containerService.AddExemplar(Item(2, Bakery), container.ContainerId);

        // Assert
        Assert.IsType<AddResult.ObxExceeded>(result);
        Assert.Single(container.Exemplars);
    }
}
