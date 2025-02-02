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
    internal class BowlingGame
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

        public void AddBonusRolls(List<Frame> bonuses)
        {
            if (frames.Count == MaxFrames)
            {
                if (bonuses.Count == 2)
                {
                    frames[MaxFrames - 1].SecondRoll = frames[0].FirstRoll;
                    frames[MaxFrames - 1].ThirdRoll = frames[1].FirstRoll;
                }
                else if(bonuses.Count == 1)
                {
                    frames[MaxFrames - 1].ThirdRoll = frames[0].FirstRoll;
                }
            }
        }

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
        public int GetStrikeBonus(int i)
        {
            if (i == MaxFrames - 1)
            {
                return frames[i].SecondRoll + frames[i].ThirdRoll;
            }
            else
            {
                if (frames[i + 1].IsStrike && i<MaxFrames-2)
                {
                    return 10 + frames[i + 2].FirstRoll;
                }
                else
                {
                    return frames[i + 1].FirstRoll + frames[i + 1].SecondRoll;
                }
            }
        }

        public int GetSpareBonus(int i)
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
                Console.WriteLine($"Frame {i + 1}");
                Console.Write("First roll: ");
                int firstRoll = Convert.ToInt32(Console.ReadLine());
                if(firstRoll == 10)
                {
                    Console.WriteLine("Strike!");
                    AddFrame(new Frame { FirstRoll = firstRoll, SecondRoll = 0 });
                    continue;
                }
                Console.Write("Second roll: ");
                int secondRoll = Convert.ToInt32(Console.ReadLine());
                if (firstRoll + secondRoll == 10)
                {
                    Console.WriteLine("Spare!");
                }
                AddFrame(new Frame { FirstRoll = firstRoll, SecondRoll = secondRoll });
            }
        }
    }
}
