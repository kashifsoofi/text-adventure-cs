namespace TextAdventure;

public class GameEngine
{
    private readonly Location[] _locations =
    [
        new ("an open field", "field"),
        new ("a little cave", "cave"),
    ];
    
    private readonly int _numberOfLocations;
    private int _locationOfPlayer;

    public GameEngine()
    {
        _numberOfLocations = _locations.Length;
        _locationOfPlayer = 0;
    }
    
    public bool ParseAndExecute(string input)
    {
        var (verb, noun) = Cut(input);
        if (!string.IsNullOrWhiteSpace(verb))
        {
            switch (verb)
            {
                case "quit": return false;
                case "look":
                    ExecuteLook(noun);
                    break;
                case "go":
                    ExecuteGo(noun);
                    break;
                default:
                    Console.WriteLine($"I don't know how to '{verb}'.");
                    break;
            }
        }

        return true;
    }

    private void ExecuteLook(string noun)
    {
        if (!string.IsNullOrEmpty(noun) &&
            noun.Equals("around", StringComparison.InvariantCultureIgnoreCase))
        {
            var location = _locations[_locationOfPlayer];
            Console.WriteLine($"You are in {location.Description}.");
        }
        else
        {
            Console.WriteLine("I don't understand what you want to see.");
        }
    }

    private void ExecuteGo(string noun)
    {
        for (var i = 0; i < _numberOfLocations; i++)
        {
            if (!string.IsNullOrEmpty(noun) &&
                noun.Equals(_locations[i].Tag, StringComparison.InvariantCultureIgnoreCase))
            {
                if (i == _locationOfPlayer)
                {
                    Console.WriteLine("You can't get much closer than this.");
                }
                else
                {
                    Console.WriteLine("OK.");
                    _locationOfPlayer = i;
                    ExecuteLook("around");
                }
                return;
            }
        }
        
        Console.WriteLine("I don't understand where you want to go.");
    }

    private static (string, string) Cut(string input)
    {
        var parts = input.Split([' ', '\n']);
        return (parts[0], parts.Length > 1 ? parts[1] : "");
    }
}