using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScorer;
using System.Collections.Generic;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class BowlingGameTests
    {
        [TestMethod]
        public void CalculateScore_AllStrikes_ReturnsPerfectGameScore()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 10 });
            }
            game.AddBonusRolls(new List<Frame> 
            { 
                new Frame { FirstRoll = 10 }, 
                new Frame { FirstRoll = 10 } 
            });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void CalculateScore_AllSparesWithFive_ReturnsScore150()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 10; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 5, SecondRoll = 5 });
            }
            game.AddBonusRolls(new List<Frame> { new Frame { FirstRoll = 5 } });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(150, score);
        }

        [TestMethod]
        public void CalculateScore_NoMarks_ReturnsSumOfPins()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 10; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 3, SecondRoll = 4 });
            }

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(70, score);
        }

        [TestMethod]
        public void CalculateScore_RandomGame_ReturnsCorrectScore()
        {
            // Arrange
            var game = new BowlingGame();

            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 7, SecondRoll = 3 }); // Spare
            game.AddFrame(new Frame { FirstRoll = 9, SecondRoll = 0 });
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 0, SecondRoll = 8 });
            game.AddFrame(new Frame { FirstRoll = 8, SecondRoll = 2 }); // Spare
            game.AddFrame(new Frame { FirstRoll = 0, SecondRoll = 6 });
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddBonusRolls(new List<Frame> 
            { 
                new Frame { FirstRoll = 8 }, 
                new Frame { FirstRoll = 1 } 
            });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(167, score);
        }

        [TestMethod]
        public void CalculateScore_GutterGame_ReturnsZero()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 10; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 0, SecondRoll = 0 });
            }

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void CalculateScore_SpareInLastFrameWithBonus_ReturnsCorrectScore()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 4, SecondRoll = 5 });
            }
            game.AddFrame(new Frame { FirstRoll = 7, SecondRoll = 3 }); // Spare in last frame
            game.AddBonusRolls(new List<Frame> { new Frame { FirstRoll = 5 } });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(96, score);
        }

        [TestMethod]
        public void CalculateScore_StrikeInLastFrameWithBonuses_ReturnsCorrectScore()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 4, SecondRoll = 5 });
            }
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike in last frame
            game.AddBonusRolls(new List<Frame>
            { 
                new Frame { FirstRoll = 10 },
                new Frame { FirstRoll = 10 }
            });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(111, score);
        }

        [TestMethod]
        public void CalculateScore_MixOfStrikesAndSpares_ReturnsCorrectScore()
        {
            // Arrange
            var game = new BowlingGame();

            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 9, SecondRoll = 1 }); // Spare
            game.AddFrame(new Frame { FirstRoll = 5, SecondRoll = 5 }); // Spare
            game.AddFrame(new Frame { FirstRoll = 7, SecondRoll = 2 });
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 9, SecondRoll = 0 });
            game.AddFrame(new Frame { FirstRoll = 8, SecondRoll = 2 }); // Spare
            game.AddBonusRolls(new List<Frame> { new Frame { FirstRoll = 9 } });

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(196, score);
        }
    }
}
