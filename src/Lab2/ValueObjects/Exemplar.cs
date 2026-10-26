using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record Exemplar(int Id, Sku Sku, ExpirationDate? Date)
{
    public Category Category => Sku.Category;

    public bool IsExpiredAt(DateTimeOffset now)
    {
        return Date?.IsExpiredAt(now) ?? false;
    }
}