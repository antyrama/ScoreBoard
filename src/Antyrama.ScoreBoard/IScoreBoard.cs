namespace Antyrama.ScoreBoard;

/// <summary>
/// Manage games and scores
/// </summary>
public interface IScoreBoard
{
    /// <summary>
    /// Starts game with 0 - 0 score
    /// </summary>
    /// <param name="homeTeamName">Home team name for new game</param>
    /// <param name="awayTeamName">Away team name for new game</param>
    /// <returns>Game unique identifier</returns>
    int StartGame(string homeTeamName, string awayTeamName);

    /// <summary>
    /// Updates game score for both teams by given game <paramref name="id"/>
    /// </summary>
    /// <param name="id">Game unique identifier</param>
    /// <param name="homeTeamScore">New home team score</param>
    /// <param name="awayTeamScore">New away team score</param>
    void UpdateScore(int id, uint homeTeamScore, uint awayTeamScore);

    /// <summary>
    /// Returns games in progress scores, ordered by summary score and time of creation
    /// </summary>
    /// <returns>Collection of <see cref="GameState"/></returns>
    IEnumerable<GameState> GetGames();

    /// <summary>
    /// Finishes game and removes in from board by given game <paramref name="id"/>
    /// </summary>
    /// <param name="id">Game unique identifier</param>
    void FinishGame(int id);
}