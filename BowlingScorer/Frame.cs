using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    /// <summary>
    /// Represents a single frame in a bowling game.
    /// </summary>
    internal class Frame
    {
        /// <summary>
        /// Gets or sets the number of pins knocked down in the first roll.
        /// </summary>
        public int FirstRoll { get; set; }

        /// <summary>
        /// Gets or sets the number of pins knocked down in the second roll.
        /// </summary>
        public int SecondRoll { get; set; }

        /// <summary>
        /// Gets or sets the number of pins knocked down in the third roll.
        /// This is only used in the 10th frame.
        /// </summary>
        public int ThirdRoll { get; set; }

        /// <summary>
        /// Gets a value indicating whether the frame is a strike.
        /// A strike occurs when all 10 pins are knocked down in the first roll.
        /// </summary>
        public bool IsStrike => FirstRoll == 10;

        /// <summary>
        /// Gets a value indicating whether the frame is a spare.
        /// A spare occurs when all 10 pins are knocked down in two rolls.
        /// </summary>
        public bool IsSpare => !IsStrike && FirstRoll + SecondRoll == 10;
    }
}
