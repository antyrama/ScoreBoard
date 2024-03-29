using FluentAssertions;
using Moq;

namespace Antyrama.ScoreBoard.UnitTests;

public class ScoreBoardTests
{
    [Fact]
    public async Task ShouldStartNewGame()
    {
        // arrange
        var sut = new ScoreBoard(GetMock());

        // act
        sut.StartGame("Mexico", "Canada");

        // assert
        var summary = sut.GetGames();
        await Verify(summary);
    }

    [Fact]
    public async Task ShouldAddNewScoreToTheGame()
    {
        // arrange
        var sut = new ScoreBoard(GetMock());
        var gameId = sut.StartGame("Mexico", "Canada");

        // act
        sut.UpdateScore(gameId, 3, 5);

        // assert
        var summary = sut.GetGames();
        await Verify(summary);
    }

    [Fact]
    public void ShouldFinishGame()
    {
        // arrange
        var sut = new ScoreBoard(GetMock());
        var gameId = sut.StartGame("Mexico", "Canada");

        // act
        sut.FinishGame(gameId);

        // assert
        var summary = sut.GetGames();
        summary.Should().BeEmpty();
    }

    [Fact]
    public async Task ShouldReturnSummaryWithCertainOrder()
    {
        // arrange
        int next = 0;

        var mock = new Mock<ISequenceProvider>();
        mock.Setup(x => x.GetNext())
            .Returns(() => next++);

        var sut = new ScoreBoard(mock.Object);

        var gameId = sut.StartGame("Mexico", "Canada");
        sut.UpdateScore(gameId, 0, 5);

        gameId = sut.StartGame("Spain", "Brazil");
        sut.UpdateScore(gameId, 10, 2);

        gameId = sut.StartGame("Germany", "France");
        sut.UpdateScore(gameId, 2, 2);

        gameId = sut.StartGame("Uruguay", "Italy");
        sut.UpdateScore(gameId, 6, 6);

        gameId = sut.StartGame("Argentina", "Australia");
        sut.UpdateScore(gameId, 3, 1);


        // act
        var summary = sut.GetGames();

        // assert
        await Verify(summary);
    }

    [Fact]
    public void ShouldThrowExceptionWhenGameNotFoundOnUpdateScore()
    {
        // arrange
        var sut = new ScoreBoard(GetMock());

        // act/assert
        Assert.Throws<InvalidOperationException>(() => sut.UpdateScore(5, 0, 5));
    }

    [Fact]
    public void ShouldThrowExceptionWhenGameNotFoundOnFinishGame()
    {
        // arrange
        var sut = new ScoreBoard(GetMock());

        // act/assert
        Assert.Throws<InvalidOperationException>(() => sut.FinishGame(5));
    }

    private static ISequenceProvider GetMock()
    {
        var mock = new Mock<ISequenceProvider>();
        mock.Setup(x => x.GetNext())
            .Returns(() => 0);

        return mock.Object;
    }
}