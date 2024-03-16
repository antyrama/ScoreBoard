namespace Antyrama.ScoreBoard;

/// <inheritdoc cref="ISequenceProvider"/>
public sealed class DefaultSequenceProvider : ISequenceProvider
{
    private int _next;

    /// <inheritdoc cref="ISequenceProvider"/>
    public int GetNext()
    {
        return _next++;
    }
}