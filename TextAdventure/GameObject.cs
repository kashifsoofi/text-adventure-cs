namespace TextAdventure;

public class GameObject(
    string Description,
    string Tag,
    GameObject? Location = null)
{
    public static GameObject Field = new GameObject("an open field", "field");
    public static GameObject Cave = new GameObject("a little cave", "cave");

    public static GameObject[] Objects =
    [
        Field,
        Cave,
        new("a silver coin", "silver", Field),
        new("a gold coin", "gold", Cave),
        new("a burly guard", "guard", Field),
        new("yourself", "yourself", Field),
    ];
}