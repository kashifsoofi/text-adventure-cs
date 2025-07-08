namespace TextAdventure;

public struct Location(
    string description,
    string tag)
{
    public string Description { get; } = description;
    public string Tag { get; } = tag;
}