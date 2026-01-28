using Game.Core;
using UnityEngine;
using VContainer;

namespace Game.UI.Panel
{
    public class GameOverPanelUI : MonoBehaviour
    {
        [Inject] private readonly GameRules _gameRules;

        [SerializeField] private Animator _animator;
        [SerializeField] private string _gameOverAnimationName = "GameOver";

        private void OnEnable()
        {
            _gameRules.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _gameRules.GameOver -= OnGameOver;
        }

        private void OnGameOver()
        {
            _animator.Play(_gameOverAnimationName);
        }
    }
}