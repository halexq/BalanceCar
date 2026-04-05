using System;
using Game.Score;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class ScoreKeeperTests
    {
        [Test]
        public void Constructor_InitializesScoreWithZero()
        {
            var scoreKeeper = new ScoreKeeper();

            Assert.That(scoreKeeper.Score, Is.EqualTo(0));
        }

        [Test]
        public void Add_UpdatesScoreAndRaisesScoreChangedWithNewValue()
        {
            var scoreKeeper = new ScoreKeeper();
            var raisedScore = -1;

            scoreKeeper.ScoreChanged += score => raisedScore = score;

            scoreKeeper.Add(5);

            Assert.That(scoreKeeper.Score, Is.EqualTo(5));
            Assert.That(raisedScore, Is.EqualTo(5));
        }

        [Test]
        public void Set_OverridesCurrentScoreAndRaisesScoreChanged()
        {
            var scoreKeeper = new ScoreKeeper();
            var raisedScore = -1;

            scoreKeeper.Add(3);
            scoreKeeper.ScoreChanged += score => raisedScore = score;

            scoreKeeper.Set(10);

            Assert.That(scoreKeeper.Score, Is.EqualTo(10));
            Assert.That(raisedScore, Is.EqualTo(10));
        }

        [Test]
        public void Reset_SetsScoreToZeroAndRaisesScoreChanged()
        {
            var scoreKeeper = new ScoreKeeper();
            var raisedScore = -1;

            scoreKeeper.Add(7);
            scoreKeeper.ScoreChanged += score => raisedScore = score;

            scoreKeeper.Reset();

            Assert.That(scoreKeeper.Score, Is.EqualTo(0));
            Assert.That(raisedScore, Is.EqualTo(0));
        }

        [Test]
        public void Add_WhenOverflowHappens_ThrowsOverflowException()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.Set(int.MaxValue);

            Assert.Throws<OverflowException>(() => scoreKeeper.Add(1));
        }
    }
}
