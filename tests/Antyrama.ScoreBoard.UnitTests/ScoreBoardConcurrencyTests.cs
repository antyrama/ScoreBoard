using Moq;

namespace Antyrama.ScoreBoard.UnitTests;

public class ScoreBoardConcurrencyTests
{
    private readonly ISequenceProvider _sequenceProvider;
    private int _next;

    public ScoreBoardConcurrencyTests()
    {
        var mock = new Mock<ISequenceProvider>();
        mock.Setup(x => x.GetNext())
            .Returns(() => _next++);

        _sequenceProvider = mock.Object;
    }

    [Fact]
    public void ShouldStartAndFinishGamesInAConcurrentWay()
    {
        // arrange
        var sut = new ScoreBoard(_sequenceProvider);

        var cts = new CancellationTokenSource();
        cts.CancelAfter(5 * 1000);

        var producerTask = new Thread(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                sut.StartGame("team1", "team2");
            }
        });

        var consumerTask = new Thread(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    sut.FinishGame(_next);
                }
                catch (InvalidOperationException)
                {
                }
            }
        });

        producerTask.Start();
        consumerTask.Start();

        producerTask.Join();
        consumerTask.Join();
    }

    [Fact]
    public void ShouldStartAndGamesAndGetGamesInAConcurrentWay()
    {
        // arrange
        var sut = new ScoreBoard(_sequenceProvider);

        var cts = new CancellationTokenSource();
        cts.CancelAfter(5 * 1000);

        var producerTask = new Thread(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                sut.StartGame("team1", "team2");
            }
        });

        var consumerTask = new Thread(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                sut.GetGames();
            }
        });

        producerTask.Start();
        consumerTask.Start();

        producerTask.Join();
        consumerTask.Join();
    }
}