namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Groups
{
    private readonly Dictionary<Category, GroupId> _groups;

    public Groups(IReadOnlyList<GroupEntry> entries)
    {
        _groups = entries.ToDictionary(entry => entry.Category, entry => entry.GroupId);
    }

    public GroupId? GetGroup(Category category)
    {
        return _groups.TryGetValue(category, out GroupId id) ? id : null;
    }
}