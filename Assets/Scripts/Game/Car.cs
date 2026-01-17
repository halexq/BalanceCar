using Game.MissileLauncher;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Car : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -5f)
            {
                GameOver();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Missile _))
            {
                return;
            }

            GameOver();
        }

        private void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}