using System;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Core
{
    public class GameRules : IStartable, IDisposable
    {
        public void Start()
        {
            Car.Died += GameOver;
        }

        private void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Dispose()
        {
            Car.Died -= GameOver;
        }
    }
}