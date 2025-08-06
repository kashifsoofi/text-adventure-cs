namespace TextAdventure;

public record Command(
    string Verb,
    string Noun)
{
    public static Command Parse(string input)
    {
        var parts = input.Split([' ', '\n']);
        return new Command(parts[0], parts.Length > 1 ? parts[1] : "");
    }
}