// See https://aka.ms/new-console-template for more information

namespace TextAdventure;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Little Cave Adventure.");

        var input = "look around";
        while (GameEngine.ParseAndExecute(input))
        {
            input = GetInput();
        }
        
        Console.WriteLine();
        Console.WriteLine("Bye!");
    }

    private static string GetInput()
    {
        Console.WriteLine();
        Console.Write("--> ");
        return Console.ReadLine()!;
    }
}