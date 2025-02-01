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
            else if (frames.Count == MaxFrames && (frames[MaxFrames - 1].IsStrike || frames[MaxFrames - 1].IsSpare))
            {
                frames[MaxFrames - 1].ThirdRoll = frame.FirstRoll;
            }
        }
    }
}
