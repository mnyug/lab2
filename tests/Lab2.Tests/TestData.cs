using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

internal static class TestData
{
    public static readonly Category Paper = new(1);
    public static readonly Category Scissors = new(2);
    public static readonly Category Stones = new(3);
    public static readonly Category Bakery = new(4);
    public static readonly Category Electronics = new(5);
    public static readonly Category Fruits = new(6);

    public static Exemplar Item(int id, Category category, ExpirationDate? date = null)
    {
        return new Exemplar(id, new Sku(category, new Obx(1, 1)), date);
    }

    public static Container NewContainer(int id, int maxObx = 10)
    {
        return new Container(new Obx(maxObx, maxObx), new ContainerId(id));
    }

    public static ContainerService Service(IReadOnlyList<GroupEntry> groups, params Container[] containers)
    {
        var repository = new Repository(containers);

        return new ContainerService(
            repository,
            new NeighborhoodService(new ProductGroup(new Groups(groups))));
    }
}
