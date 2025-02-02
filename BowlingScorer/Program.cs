using BowlingScorer;

var game = new BowlingGame();

game.ReadData();
Console.WriteLine($"Total Score is {game.CalculateScore()}");