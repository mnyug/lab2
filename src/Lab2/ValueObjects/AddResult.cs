namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public abstract record AddResult
{
    private AddResult() { }

    public sealed record Success(ContainerId ContainerId) : AddResult;

    public sealed record NeighborhoodNotAllowed : AddResult;

    public sealed record ObxExceeded : AddResult;

    public sealed record ExpirationNotAllowed : AddResult;

    public sealed record NoAvailableContainer : AddResult;
}