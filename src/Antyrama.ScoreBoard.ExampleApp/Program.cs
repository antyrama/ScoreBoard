using Antyrama.ScoreBoard;

var sequenceProvider = new DefaultSequenceProvider();
var board = new ScoreBoard(sequenceProvider);

var gameId = board.StartGame("Mexico", "Canada");
board.UpdateScore(gameId, 0, 5);

gameId = board.StartGame("Spain", "Brazil");
board.UpdateScore(gameId, 10, 2);

gameId = board.StartGame("Germany", "France");
board.UpdateScore(gameId, 2, 2);

gameId = board.StartGame("Uruguay", "Italy");
board.UpdateScore(gameId, 6, 6);

gameId = board.StartGame("Argentina", "Australia");
board.UpdateScore(gameId, 3, 1);

Console.WriteLine("Live Football World Cup Score Board");
Console.WriteLine();

foreach (var game in board.GetGames())
{
    Console.WriteLine($"{game.HomeTeam.Name} {game.HomeTeam.Score} - {game.AwayTeam.Name} {game.AwayTeam.Score}");
}

Console.ReadKey();
