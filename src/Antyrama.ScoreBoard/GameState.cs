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
    public string Id { get; init; } = default!;

    /// <summary>
    /// Indicates time of creation a game
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// A home team
    /// </summary>
    public Team HomeTeam { get; init; } = default!;

    /// <summary>
    /// An away team
    /// </summary>
    public Team AwayTeam { get; init; } = default!;
}