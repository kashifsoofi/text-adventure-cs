namespace TextAdventure;

public interface IInputOutputManager
{
    Command GetInput();
}

public class InputOutputManager(
    ITextReader reader,
    ITextWriter writer) : IInputOutputManager
{
    public Command GetInput()
    {
        writer.WriteLine();
        writer.Write("--> ");
        var input = reader.ReadLine();
        return Command.Parse(input);
    }
}