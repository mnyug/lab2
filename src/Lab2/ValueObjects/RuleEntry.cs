using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public readonly record struct RuleEntry(Category Category, IRule Rule);