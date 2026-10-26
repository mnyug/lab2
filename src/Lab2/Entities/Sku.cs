using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public record Sku
{
    public Sku(Category category, Obx weight)
    {
        if (weight <= Obx.Zero)
            throw new ArgumentOutOfRangeException(nameof(weight), "ОВХ товара должны быть положительными ");

        Category = category;
        Weight = weight;
    }

    public Category Category { get; }

    public Obx Weight { get; }
}