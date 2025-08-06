namespace TextAdventure;

public class Object(
    string description,
    string tag,
    Object? location = null)
{
    public string Description { get; } = description;
    public string Tag { get; } = tag;
    public Object? Location { get; set;  } = location;

    private static readonly Object Field = new Object("an open field", "field");
    private static readonly Object Cave = new Object("a little cave", "cave");

    public static Object[] Objects =
    [
        Field,
        Cave,
        new("a silver coin", "silver", Field),
        new("a gold coin", "gold", Cave),
        new("a burly guard", "guard", Field),
        new("yourself", "yourself", Field),
    ];

}