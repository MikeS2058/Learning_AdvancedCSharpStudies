using FluentAssertions;
using Learning_AdvancedCSharpStudies.IndexerStudites;

namespace Tests_LearningAdvancedCSharpStudies;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var noteBooks = new NoteBooks
        {
            [0] = "Introduction to C#",
            [1] = "Advanced C# Concepts"
        };

        // Check using fluent assertions if the notes are correctly set
        noteBooks[0].Should().Be("Introduction to C#");
    }
}