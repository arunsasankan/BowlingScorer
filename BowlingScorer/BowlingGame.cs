using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    /// <summary>
    /// Represents a bowling game consisting of multiple frames.
    /// </summary>
    public class BowlingGame
    {
        /// <summary>
        /// List of frames in the bowling game.
        /// </summary>
        private List<Frame> frames = new List<Frame>();

        /// <summary>
        /// Maximum number of frames in a bowling game.
        /// </summary>
        private const int MaxFrames = 10;

        /// <summary>
        /// Adds a frame to the bowling game.
        /// </summary>
        /// <param name="frame">The frame to add.</param>
        public void AddFrame(Frame frame)
        {
            if (frames.Count < MaxFrames)
            {
                frames.Add(frame);
            }
        }

        /// <summary>
        /// Adds bonus rolls to the final frame if applicable.
        /// </summary>
        /// <param name="bonuses">List of bonus frames.</param>
        public void AddBonusRolls(List<Frame> bonuses)
        {
            if (frames.Count == MaxFrames)
            {
                if (bonuses.Count == 2)
                {
                    frames[MaxFrames - 1].SecondRoll = bonuses[0].FirstRoll;
                    frames[MaxFrames - 1].ThirdRoll = bonuses[1].FirstRoll;
                }
                else if (bonuses.Count == 1)
                {
                    frames[MaxFrames - 1].ThirdRoll = bonuses[0].FirstRoll;
                }
            }
        }

        /// <summary>
        /// Calculates the total score of the bowling game.
        /// </summary>
        /// <returns>The total score.</returns>
        public int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].IsStrike)
                {
                    score += 10 + GetStrikeBonus(i);
                }
                else if (frames[i].IsSpare)
                {
                    score += 10 + GetSpareBonus(i);
                }
                else
                {
                    score += frames[i].FirstRoll + frames[i].SecondRoll;
                }
            }
            return score;
        }

        /// <summary>
        /// Gets the bonus score for a strike.
        /// </summary>
        /// <param name="i">The index of the frame.</param>
        /// <returns>The bonus score for the strike.</returns>
        private int GetStrikeBonus(int i)
        {
            if (i == MaxFrames - 1)
            {
                return frames[i].SecondRoll + frames[i].ThirdRoll;
            }
            else
            {
                if (frames[i + 1].IsStrike && i < MaxFrames - 2)
                {
                    return 10 + frames[i + 2].FirstRoll;
                }
                else
                {
                    return frames[i + 1].FirstRoll + frames[i + 1].SecondRoll;
                }
            }
        }

        /// <summary>
        /// Gets the bonus score for a spare.
        /// </summary>
        /// <param name="i">The index of the frame.</param>
        /// <returns>The bonus score for the spare.</returns>
        private int GetSpareBonus(int i)
        {
            if (i == MaxFrames - 1)
            {
                return frames[i].ThirdRoll;
            }
            else
            {
                return frames[i + 1].FirstRoll;
            }
        }
        public void ReadData()
        {
            for (int i = 0; i < MaxFrames; i++)
            {
                Console.WriteLine($"---------- Frame {i + 1} ----------");

                int firstRoll = GetRollInput("First roll: ", 0, 10);
                if (firstRoll == 10)
                {
                    Console.WriteLine("Strike! ( X )");
                    AddFrame(new Frame { FirstRoll = 10, SecondRoll = 0 });
                    Console.WriteLine($"-----------------------------\n");
                    continue;
                }

                int secondRoll = GetRollInput("Second roll: ", 0, 10 - firstRoll);
                if (firstRoll + secondRoll == 10)
                {
                    Console.WriteLine("Spare! ( / )");
                }
                AddFrame(new Frame { FirstRoll = firstRoll, SecondRoll = secondRoll });
                Console.WriteLine($"-----------------------------\n");
            }

            HandleBonusRolls();
        }

        /// <summary>
        /// Prompts the user for roll input and validates it.
        /// </summary>
        private int GetRollInput(string prompt, int min, int max)
        {
            int roll;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out roll) && roll >= min && roll <= max)
                {
                    return roll;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }

        /// <summary>
        /// Handles the bonus rolls for the 10th frame if necessary.
        /// </summary>
        private void HandleBonusRolls()
        {
            var lastFrame = frames[MaxFrames - 1];
            if (lastFrame.IsStrike)
            {
                Console.WriteLine($"-------- Bonus Rolls ---------");
                int firstBonus = GetRollInput("First bonus roll: ", 0, 10);
                if (firstBonus == 10)
                {
                    Console.WriteLine("Strike! ( X )\n");
                }

                int secondBonus = GetRollInput("Second bonus roll: ", 0, 10);
                if (secondBonus == 10)
                {
                    Console.WriteLine("Strike! ( X )\n");
                }
                AddBonusRolls(new List<Frame> { new Frame { FirstRoll = firstBonus }, new Frame { FirstRoll = secondBonus } });
                Console.WriteLine($"-----------------------------\n");
            }
            else if (lastFrame.IsSpare)
            {
                Console.WriteLine($"-------- Bonus Roll ---------");
                int bonusRoll = GetRollInput("Bonus roll: ", 0, 10);
                if (bonusRoll == 10)
                {
                    Console.WriteLine("Strike! ( X )\n");
                }
                AddBonusRolls(new List<Frame> { new Frame { FirstRoll = bonusRoll } });
                Console.WriteLine($"-----------------------------\n");
            }
        }

    }
}
