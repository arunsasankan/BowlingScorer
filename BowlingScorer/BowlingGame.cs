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
        private void AddFrame(Frame frame)
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
        private void AddBonusRolls(List<Frame> bonuses)
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

        /// <summary>
        /// Reads the data for each frame from the console.
        /// </summary>
        public void ReadData()
        {
            for (int i = 0; i < MaxFrames; i++)
            {
                Console.WriteLine($"***** Frame {i + 1} *****");
                Console.Write("First roll: ");
                int firstRoll = Convert.ToInt32(Console.ReadLine());
                if (firstRoll == 10)
                {
                    Console.WriteLine("Strike!");
                    AddFrame(new Frame { FirstRoll = firstRoll, SecondRoll = 0 });
                    Console.WriteLine();
                    continue;
                }
                Console.Write("Second roll: ");
                int secondRoll = Convert.ToInt32(Console.ReadLine());
                if (firstRoll + secondRoll == 10)
                {
                    Console.WriteLine("Spare!");
                    Console.WriteLine();
                }
                AddFrame(new Frame { FirstRoll = firstRoll, SecondRoll = secondRoll });
            }
            if (frames[MaxFrames - 1].IsStrike)
            {
                Console.WriteLine("***** Bonus Rolls *****");
                Console.Write("First bonus roll: ");
                int firstBonus = Convert.ToInt32(Console.ReadLine());
                if (firstBonus == 10)
                {
                    Console.WriteLine("Strike!");
                    Console.WriteLine();
                    Console.Write("Second bonus roll: ");
                    int secondBonus = Convert.ToInt32(Console.ReadLine());
                    if (secondBonus == 10)
                    {
                        Console.WriteLine("Strike!");
                        Console.WriteLine();
                    }
                    AddBonusRolls(new List<Frame> { new Frame { FirstRoll = firstBonus }, new Frame { FirstRoll = secondBonus } });
                }
                else
                {
                    Console.Write("Second bonus roll: ");
                    int secondBonus = Convert.ToInt32(Console.ReadLine());
                    if (firstBonus + secondBonus == 10)
                    {
                        Console.WriteLine("Spare!");
                        Console.WriteLine();
                    }
                    AddBonusRolls(new List<Frame> { new Frame { FirstRoll = firstBonus }, new Frame { FirstRoll = secondBonus } });
                }
            }
            else if (frames[MaxFrames - 1].IsSpare)
            {
                Console.WriteLine("***** Bonus Roll *****");
                Console.Write("Bonus roll: ");
                int bonus = Convert.ToInt32(Console.ReadLine());
                if (bonus == 10)
                {
                    Console.WriteLine("Strike!");
                    Console.WriteLine();
                }
                AddBonusRolls(new List<Frame> { new Frame { FirstRoll = bonus } });
            }
        }
    }
}
