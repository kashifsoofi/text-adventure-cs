namespace TextAdventure;

public interface ITextReader
{
    string ReadLine();
}

public class ConsoleTextReader(TextReader reader) : ITextReader
{
    public string ReadLine()
    {
        return reader.ReadLine()!;
    }
}