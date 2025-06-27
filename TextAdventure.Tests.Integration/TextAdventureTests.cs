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
        
        var expected = File.ReadAllText("baseline.txt");

        // Act
        Program.Main([]);
        
        // Assert
        sw.ToString().ShouldBe(expected);
    }
}