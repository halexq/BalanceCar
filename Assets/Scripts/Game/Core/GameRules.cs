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
        
        private readonly FirebaseRemoteConfigLoader _firebaseRemoteConfigLoader;

        public GameRules(FirebaseRemoteConfigLoader firebaseRemoteConfigLoader)
        {
            _firebaseRemoteConfigLoader = firebaseRemoteConfigLoader;
        }

        public void Start()
        {
            _delayBeforeGameOver = (float)_firebaseRemoteConfigLoader.Config[FirebaseRemoteConfigLoader.DelayBeforeGameOverKey].DoubleValue;

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