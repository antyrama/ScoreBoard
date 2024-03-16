namespace Antyrama.ScoreBoard;

/// <summary>
/// Serves sequence of <see cref="int"/> values
/// </summary>
public interface ISequenceProvider
{
    /// <summary>
    /// Returns next value of <see cref="int"/> in sequence
    /// </summary>
    int GetNext();
}