namespace TextAdventure;

public class World(ITextWriter writer)
{
    private readonly Object[] _objects = Object.AllObjects;
    
    private readonly Object _player = Object.Player;

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
            var output = $"You are in {_player.Location!.Description}.\n";
            var objs = ListObjectsAtLocation(_player.Location);
            output += "You see:\n" + string.Join("\n", objs.Select(o => o.Description));
            return output;
        }
        
        return "I don't understand what you want to see.";
    }
    
    private string ExecuteGo(string noun)
    {
        var (obj, output) = GetVisible("where you want to go", noun);
        if (obj == null)
        {
            return output;
        }

        if (obj.Location == null && obj != _player.Location)
        {
            _player.Location = obj;
            output = ExecuteLook("around");
            return $"OK.\n{output}";
        }
        
        return "You can't get much closer than this.";
    }

    private Object? GetObject(string noun)
    {
        return _objects.FirstOrDefault(o => o.Tag == noun);
    }

    private (Object?, string) GetVisible(string intention, string noun)
    {
        var obj = GetObject(noun);
        if (obj is null)
        {
            return (null, $"I don't understand {intention}.\n");
        }

        var output = "";
        if (!(obj == _player ||
              obj == _player.Location ||
              obj.Location == _player ||
              obj.Location == _player.Location ||
              obj.Location is null ||
              obj.Location.Location == _player ||
              obj.Location.Location == _player.Location))
        {
            output = $"You don't see any {noun} here.\n";
            obj = null;
        }

        return (obj, output);
    }

    private List<Object> ListObjectsAtLocation(Object location)
    {
        return Object.AllObjects.Where(x => x != _player && x.Location == location).ToList();
    }
    
    public void UpdateScreen(string text)
    {
        writer.WriteLine(text);
    }
}