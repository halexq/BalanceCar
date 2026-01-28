using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Core
{
    public class GameRules : IStartable, IDisposable
    {
        public event Action GameOver; 

        public void Start()
        {
            Car.Died += EndGame;
        }

        private void EndGame()
        {
            EndGameAsync().Forget();
        }

        private async UniTask EndGameAsync()
        {
            GameOver?.Invoke();

            await UniTask.Delay(TimeSpan.FromSeconds(1));

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Dispose()
        {
            Car.Died -= EndGame;
        }
    }
}