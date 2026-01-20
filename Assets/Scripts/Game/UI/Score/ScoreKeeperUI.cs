using Game.Score;
using TMPro;
using UnityEngine;

namespace Game.UI.Score
{
    public class ScoreKeeperUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private IScoreSource _scoreSource;

        public void Bind()
        {
            _scoreSource.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _scoreSource.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}