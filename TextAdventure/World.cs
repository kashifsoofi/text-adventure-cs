namespace TextAdventure;

public class World(ITextWriter writer)
{
    private readonly Object[] _locations =
    [
        new ("an open field", "field"),
        new ("a little cave", "cave"),
    ];
    
    private int NumberOfLocations => _locations.Length;
    private int _locationOfPlayer = 0;

    public string UpdateState(Command command)
    {
        var output = command.Verb switch
        {
            "quit" => "",
            "look" => ExecuteLook(command.Noun),
            "go" => ExecuteGo(command.Noun),
            _ => $"I don't know how to '{command.Verb}'."
        };

        return output;
    }

    private string ExecuteLook(string noun)
    {
        if (!string.IsNullOrEmpty(noun) &&
            noun.Equals("around", StringComparison.InvariantCultureIgnoreCase))
        {
            var location = _locations[_locationOfPlayer];
            return $"You are in {location.Description}.";
        }
        
        return "I don't understand what you want to see.";
    }
    
    private string ExecuteGo(string noun)
    {
        for (var i = 0; i < NumberOfLocations; i++)
        {
            if (!string.IsNullOrEmpty(noun) &&
                noun.Equals(_locations[i].Tag, StringComparison.InvariantCultureIgnoreCase))
            {
                if (i == _locationOfPlayer)
                {
                    return "You can't get much closer than this.";
                }

                var output = "OK.\n";
                _locationOfPlayer = i;
                return output + ExecuteLook("around");
            }
        }
        
        return "I don't understand where you want to go.";
    }
    
    public void UpdateScreen(string text)
    {
        writer.WriteLine(text);
    }
}