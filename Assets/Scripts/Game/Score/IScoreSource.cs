using System;

namespace Game.Score
{
    public interface IScoreSource
    {
        int Score { get; }

        event Action<int> ScoreChanged;
    }
}