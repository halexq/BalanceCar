using Game.MissileLauncher;
using Game.Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Core
{
    public class Car : MonoBehaviour
    {
        [Inject] private readonly IScoreSource _scoreKeeper;

        [SerializeField] private float _addScoreCooldown;
        private float _time;
        private float _lastAddTime;

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _addScoreCooldown && _lastAddTime + _addScoreCooldown <= Time.time)
            {
                _scoreKeeper.Add(1);
                _lastAddTime = _time;
            }

            if (transform.position.y < -3f)
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