namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public readonly record struct Category
{
    public Category(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id не может быть отрицательным");
        }

        Id = id;
    }

    public int Id { get; }
}