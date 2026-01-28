using System;

namespace Game.Score
{
    public interface IScoreSource
    {
        int Score { get; }

        event Action<int> ScoreChanged;

        void Add(int score);

        void Reset();

        void Set(int value);
    }
}