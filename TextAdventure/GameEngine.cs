namespace TextAdventure;

public class GameEngine
{
    public static bool ParseAndExecute(string input)
    {
        var (verb, noun) = Cut(input);
        if (!string.IsNullOrWhiteSpace(verb))
        {
            switch (verb)
            {
                case "quit": return false;
                case "look":
                    Console.WriteLine("It is very dark in here.");
                    break;
                case "go":
                    Console.WriteLine("It's too dark to go anywhere.");
                    break;
                default:
                    Console.WriteLine($"I don't know how to '{verb}'.");
                    break;
            }
        }

        return true;
    }

    private static (string, string) Cut(string input)
    {
        var parts = input.Split([' ', '\n']);
        return (parts[0], parts.Length > 1 ? parts[1] : "");
    }
}