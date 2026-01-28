using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Core
{
    public class GameRules : IStartable
    {
        public void Start()
        {
            Car.Died += GameOver;
        }

        private void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}