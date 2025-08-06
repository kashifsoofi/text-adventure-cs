namespace TextAdventure;

public class Object(
    string description,
    string tag,
    Object? location = null)
{
    public string Description { get; } = description;
    public string Tag { get; } = tag;
    public Object? Location { get; set;  } = location;

    public static readonly Object Field = new Object("an open field", "field");
    public static readonly Object Cave = new Object("a little cave", "cave");
    public static readonly Object Player = new Object("yourself", "yourself", Field);

    public static readonly Object[] AllObjects =
    [
        Field,
        Cave,
        new("a silver coin", "silver", Field),
        new("a gold coin", "gold", Cave),
        new("a burly guard", "guard", Field),
        Player,
    ];

}