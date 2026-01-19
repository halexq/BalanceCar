using Game.Score;
using TMPro;
using UnityEngine;
using VContainer;

namespace Game.UI.Score
{
    public class ScoreKeeperUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        [Inject] private readonly ScoreKeeper _scoreSource;

        private void OnEnable()
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