using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Expiration;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab2.Tests.TestData;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PalletRuleTests
{
    private readonly FakeDateTime _clock = new(new DateTimeOffset(2026, 1, 10, 0, 0, 0, TimeSpan.Zero));
    private readonly Container _expiredContainer = NewContainer(1);
    private readonly Container _freshContainer = NewContainer(2);

    [Fact]
    public void ExpiredToExpiredContainer()
    {
        // Arrange
        PalletRule pallet = CreatePallet();
        Exemplar expired = Item(1, Bakery, new ExpirationDate(_clock.Now.AddDays(-1)));

        // Act
        AddResult result = pallet.Execute(expired);

        // Assert
        Assert.Equal(new AddResult.Success(_expiredContainer.ContainerId), result);
        Assert.Empty(_freshContainer.Exemplars);
    }

    [Fact]
    public void FreshToFreshContainer()
    {
        // Arrange
        PalletRule pallet = CreatePallet();
        Exemplar fresh = Item(1, Bakery, new ExpirationDate(_clock.Now.AddDays(1)));

        // Act
        AddResult result = pallet.Execute(fresh);

        // Assert
        Assert.Equal(new AddResult.Success(_freshContainer.ContainerId), result);
        Assert.Empty(_expiredContainer.Exemplars);
    }

    private PalletRule CreatePallet()
    {
        ContainerService containerService = Service([], _expiredContainer, _freshContainer);

        return new PalletRule([
            new ExpirationDateRule(new ContainerRule(_expiredContainer.ContainerId, containerService), new ExpiredCondition(), _clock),
            new ExpirationDateRule(new ContainerRule(_freshContainer.ContainerId, containerService), new NotExpiredCondition(), _clock),
        ]);
    }
}
