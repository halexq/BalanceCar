using System;

namespace Game.Score
{
    /// <summary>
    /// Stores and manages an integer score value.
    /// </summary>
    public class ScoreKeeper : IScoreSource
    {
        /// <summary>
        /// Gets the current score value.
        /// </summary>
        public int Score { get; private set; }

        public event Action<int> ScoreChanged;

        /// <summary>
        /// Initializes a new instance of <see cref="ScoreKeeper"/> with score set to zero.
        /// </summary>
        public ScoreKeeper()
        {
            Score = 0;
        }

        /// <summary>
        /// Adds the specified amount to the score.
        /// </summary>
        /// <param name="amount">Amount to add. Can be negative.</param>
        public void Add(int amount)
        {
            checked
            {
                Score += amount;
            }

            ScoreChanged?.Invoke(Score);
        }

        /// <summary>
        /// Resets the score to zero.
        /// </summary>
        public void Reset()
        {
            Score = 0;

            ScoreChanged?.Invoke(Score);
        }

        /// <summary>
        /// Sets the score to a specific value.
        /// </summary>
        /// <param name="value">New score value.</param>
        public void Set(int value)
        {
            Score = value;

            ScoreChanged?.Invoke(Score);
        }
    }
}