using System.Collections.Immutable;

namespace Antyrama.ScoreBoard;

/// <inheritdoc cref="IScoreBoard"/>
public sealed class ScoreBoard : IScoreBoard
{
    private readonly ISequenceProvider _sequenceProvider;
    private readonly Dictionary<int, GameState> _gameStates = new();
    private readonly object _lock = new();

    /// <summary>
    /// Creates instance of <see cref="ScoreBoard"/>
    /// </summary>
    /// <param name="sequenceProvider">Instance of implementation of <see cref="ISequenceProvider"/></param>
    public ScoreBoard(ISequenceProvider sequenceProvider)
    {
        _sequenceProvider = sequenceProvider;
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public int StartGame(string homeTeamName, string awayTeamName)
    {
        lock (_lock)
        {
            var id = _sequenceProvider.GetNext();

            var state = new GameState
            {
                Id = id,
                HomeTeam = new Team
                {
                    Name = homeTeamName
                },
                AwayTeam = new Team
                {
                    Name = awayTeamName
                }
            };

            _gameStates.Add(id, state);

            return state.Id;
        }
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public void UpdateScore(int id, uint homeTeamScore, uint awayTeamScore)
    {
        if (!_gameStates.TryGetValue(id, out var state))
        {
            throw new InvalidOperationException($"Game with [{id}] does not exist");
        }

        state.HomeTeam.Score = homeTeamScore;
        state.AwayTeam.Score = awayTeamScore;
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public IEnumerable<GameState> GetGames()
    {
        lock (_lock)
        {
            return _gameStates.Values
                .Order(ScoreCreationGameStateComparer.Instance)
                .ToImmutableArray();
        }
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public void FinishGame(int id)
    {
        lock (_lock)
        {
            if (!_gameStates.ContainsKey(id))
            {
                throw new InvalidOperationException($"Game with [{id}] does not exist");
            }

            _gameStates.Remove(id);
        }
    }
}

internal sealed class ScoreCreationGameStateComparer : IComparer<GameState>
{
    public static readonly ScoreCreationGameStateComparer Instance = new();

    public int Compare(GameState? x, GameState? y)
    {
        var scoreResult = y!.OverallScore.CompareTo(x!.OverallScore);
        if (scoreResult == 0)
        {
            return y.Id.CompareTo(x.Id);
        }

        return scoreResult;
    }
}
