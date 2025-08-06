// See https://aka.ms/new-console-template for more information

namespace TextAdventure;

public static class Program
{
    public static void Main(string[] args)
    {
        var writer = new ConsoleTextWriter(Console.Out);
        var inputOutputManager = new InputOutputManager(new ConsoleTextReader(Console.In), writer);
        var gameState = new World(writer);
        
        writer.WriteLine("Welcome to Little Cave Adventure.");

        var command = Command.Parse("look around");
        while (command.Verb != "quit")
        {
            var output = gameState.UpdateState(command);
            gameState.UpdateScreen(output);
            command = inputOutputManager.GetInput();
        }
        
        writer.WriteLine();
        writer.WriteLine("Bye!");
    }
}