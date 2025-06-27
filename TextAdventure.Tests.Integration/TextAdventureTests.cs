using Shouldly;

namespace TextAdventure.Tests.Integration;

public class TextAdventureTests
{
    [Fact]
    public void TestMain()
    {
        // Arrange
        using var sw = new StringWriter();
        Console.SetOut(sw);

        var input = File.ReadAllText("TestScript.txt").Replace("\r\n", "\n");
        using var sr = new StringReader(input);
        Console.SetIn(sr);
        
        var expected = File.ReadAllText("BaseLine1.txt");

        // Act
        Program.Main([]);
        
        // Assert
        var output = GetNormalisedOutput(sw, input);
        output.ShouldBe(expected);
    }

    private string GetNormalisedOutput(StringWriter sw, string input)
    {
        var output = sw.ToString();
        var outputLines = output.Replace("--> ", "--> \n") .Split('\n');;
        var inputLines = input.Split("\n");

        var j = 0;
        for (var i = 0; i < outputLines.Length; i++)
        {
            if (outputLines[i].StartsWith("--> "))
            {
                outputLines[i] = $"--> {inputLines[j]}";
                j++;
            }
        }

        return string.Join('\n', outputLines);
    }
}