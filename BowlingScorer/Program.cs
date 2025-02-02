using BowlingScorer;

var game = new BowlingGame();

// Create and add frames to the game
for (int i = 0; i < 10; i++)
{
    var frame = new Frame { FirstRoll = 10, SecondRoll = 0 };
    game.AddFrame(frame);
}

//adding bonus rolls
List<Frame> bonusRolls = new List<Frame>()
{
    new Frame { FirstRoll = 10, SecondRoll = 0 },
    new Frame { FirstRoll = 10, SecondRoll = 0 }
};

game.AddBonusRolls(bonusRolls);
var score = game.CalculateScore();

Console.WriteLine("Game created with 10 frames.");

//var score = game.CalculateScore();