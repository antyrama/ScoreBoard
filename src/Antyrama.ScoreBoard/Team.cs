namespace Antyrama.ScoreBoard;

/// <summary>
/// Identifies team name and their score
/// </summary>
public sealed class Team
{
    internal Team()
    {
    }

    /// <summary>
    /// Name of the team
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Score of the team
    /// </summary>
    public uint Score { get; init; } = default!;

    /// <inheritdoc cref="object"/>
    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Team other && Equals(other);
    }

    /// <inheritdoc cref="object"/>
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    private bool Equals(Team other)
    {
        return Name == other.Name;
    }
}