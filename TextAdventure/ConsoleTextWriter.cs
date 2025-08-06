namespace TextAdventure;

public interface ITextWriter
{
    void WriteLine(string text = "");
    void  Write(string text = "");
}

public class ConsoleTextWriter(TextWriter writer) : ITextWriter
{
    public void WriteLine(string text = "")
    {
        Console.WriteLine(text);
    }

    public void Write(string text = "")
    {
        writer.Write(text);
    }
}