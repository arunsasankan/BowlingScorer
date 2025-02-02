using BowlingScorer;

var game = new BowlingGame();//Creating a new instance of BowlingGame
Console.WriteLine("Bowling Scorer\n");
game.ReadData();//Reading the data from the console
Console.WriteLine($"Total Score is {game.CalculateScore()}");//Printing the total score to the console