using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScorer;
using System.Collections.Generic;

namespace BowlingScorer.Tests
{
    /// <summary>
    /// Contains unit tests for the BowlingGame class.
    /// </summary>
    [TestClass]
    public class BowlingGameTests
    {
        /// <summary>
        /// Tests that a perfect game (all strikes) returns a score of 300.
        /// </summary>
        [TestMethod]
        public void CalculateScore_AllStrikes_ReturnsPerfectGameScore()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 10; i++)
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

        /// <summary>
        /// Tests that a game with all rolls knocking down one pin returns a score of 20.
        /// </summary>
        [TestMethod]
        public void CalculateScore_AllOneGame_ReturnsScore20()
        {
            // Arrange
            var game = new BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 1, SecondRoll = 1 });
            }

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(20, score);
        }

        /// <summary>
        /// Tests that a spare followed by a roll of 3 returns a score of 16.
        /// </summary>
        [TestMethod]
        public void CalculateScore_SpareFollowedBy3_Returns16()
        {
            // Arrange
            var game = new BowlingGame();

            game.AddFrame(new Frame { FirstRoll = 5, SecondRoll = 5 }); // Spare
            game.AddFrame(new Frame { FirstRoll = 3, SecondRoll = 0 }); // Followed by 3
            for (int i = 0; i < 8; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 0, SecondRoll = 0 });//Rest all gutter balls
            }

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(16, score);
        }

        /// <summary>
        /// Tests that a strike followed by rolls of 3 and 4 returns a score of 24.
        /// </summary>
        [TestMethod]
        public void CalculateScore_StrikeFollowedBy3and4_Returns24()
        {
            // Arrange
            var game = new BowlingGame();

            game.AddFrame(new Frame { FirstRoll = 10 }); // Strike
            game.AddFrame(new Frame { FirstRoll = 3, SecondRoll = 4 }); // Followed by 3 & 4
            for (int i = 0; i < 8; i++)
            {
                game.AddFrame(new Frame { FirstRoll = 0, SecondRoll = 0 });//Rest all gutter balls
            }

            // Act
            int score = game.CalculateScore();

            // Assert
            Assert.AreEqual(24, score);
        }

        /// <summary>
        /// Tests that a game with all gutter balls returns a score of 0.
        /// </summary>
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

        /// <summary>
        /// Tests that a game with all spares and a bonus roll of 5 returns a score of 150.
        /// </summary>
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

        /// <summary>
        /// Tests that a game with no marks (strikes or spares) returns the sum of all pins knocked down.
        /// </summary>
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

        /// <summary>
        /// Tests that a random game returns the correct score.
        /// </summary>
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

        /// <summary>
        /// Tests that a spare in the last frame with a bonus roll returns the correct score.
        /// </summary>
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

        /// <summary>
        /// Tests that a strike in the last frame with bonus rolls returns the correct score.
        /// </summary>
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

        /// <summary>
        /// Tests that a mix of strikes and spares returns the correct score.
        /// </summary>
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
