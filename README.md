# Score Board

Simple library to manage games score board

## Requirements
Any machine with installed:
* .NET 7.0 SDK
* .NET 8.0 SDK

[Download .NET SDKs for Visual Studio](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

## Develop & run
Open solution/folder in any IDE and run `Antyrama.ScoreBoard.ExampleApp` console application

## Usage
``` c#
var sequenceProvider = new DefaultSequenceProvider();
var scoreBoard = new ScoreBoard(sequenceProvider);

var gameId = scoreBoard.StartGame("Mexico", "Canada");
scoreBoard.UpdateScore(gameId, 0, 5);

gameId = scoreBoard.StartGame("Spain", "Brazil");
scoreBoard.UpdateScore(gameId, 10, 2);

gameId = scoreBoard.StartGame("Germany", "France");
scoreBoard.UpdateScore(gameId, 2, 2);

gameId = scoreBoard.StartGame("Uruguay", "Italy");
scoreBoard.UpdateScore(gameId, 6, 6);

gameId = scoreBoard.StartGame("Argentina", "Australia");
scoreBoard.UpdateScore(gameId, 3, 1);

var summary = scoreBoard.GetGames();
```

## Remarks
* Models are partially mutable, in an effect I wasn't able to use sorted collections to keep board sorted in a certain way
* Not using concurent collections as starting game will always create a new game in a dictionary and updating score does not involve removing/adding items over collection
* Exposed `ISequenceProvider` interface to make users able to provide their own solution, with assupmtion here - next value have to be always greater
* Exposed `IScoreBoard` interface to allow easy mocking

## Dependencies
Library `Antyrama.ScoreBoard` does not use any other 3rd party dependencies, just pure framework and it's ready to be packed into nuGet package.

Used in tests project:
* [Fluent Assertions](https://github.com/fluentassertions/fluentassertions)
* [Moq](https://github.com/devlooped/moq)
* [Verify](https://github.com/VerifyTests/Verify)