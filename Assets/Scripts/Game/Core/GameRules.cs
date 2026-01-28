using System;
using Cysharp.Threading.Tasks;
using Engine.Firebase;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Core
{
    public class GameRules : IStartable, IDisposable
    {
        public event Action GameOver;

        private float _delayBeforeGameOver = 1f;
        
        private readonly RemoteConfigLoader _remoteConfigLoader;

        public GameRules(RemoteConfigLoader remoteConfigLoader)
        {
            _remoteConfigLoader = remoteConfigLoader;
        }

        public void Start()
        {
            _delayBeforeGameOver = (float)_remoteConfigLoader.Config[RemoteConfigLoader.DelayBeforeGameOverKey].DoubleValue;

            Car.Died += EndGame;
        }

        private void EndGame()
        {
            EndGameAsync().Forget();
        }

        private async UniTask EndGameAsync()
        {
            GameOver?.Invoke();

            await UniTask.Delay(TimeSpan.FromSeconds(_delayBeforeGameOver));

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Dispose()
        {
            Car.Died -= EndGame;
        }
    }
}