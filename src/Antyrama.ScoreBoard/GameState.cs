namespace Antyrama.ScoreBoard;

/// <summary>
/// Keeps state of a game
/// </summary>
public sealed class GameState
{
    internal GameState()
    {
    }

    /// <summary>
    /// Unique identifier of game
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// A home team
    /// </summary>
    public Team HomeTeam { get; init; } = default!;

    /// <summary>
    /// An away team
    /// </summary>
    public Team AwayTeam { get; init; } = default!;

    internal uint OverallScore => HomeTeam.Score + AwayTeam.Score;
}