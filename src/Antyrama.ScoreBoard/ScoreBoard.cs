namespace Antyrama.ScoreBoard;

/// <inheritdoc cref="IScoreBoard"/>
public sealed class ScoreBoard : IScoreBoard
{
    /// <inheritdoc cref="IScoreBoard"/>
    public string StartGame(string homeTeamName, string awayTeamName)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public void UpdateScore(string id, int homeTeamScore, int awayTeamScore)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public IEnumerable<GameState> GetGames()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IScoreBoard"/>
    public void FinishGame(string id)
    {
        throw new NotImplementedException();
    }
}
