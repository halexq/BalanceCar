using Game.Core;
using Game.Score;
using Game.Spawning.Interface;
using UnityEngine;
using VContainer;

namespace Game.Spawning.Spawnable
{
    public class Coin : MonoBehaviour, ILaunchable
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private int _addScoreAmount = 3;

        [Inject] private readonly IScoreSource _score;

        public void Launch()
        {
            _rb.gravityScale = 1f;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Car _))
            {
                return;
            }

            _score.Add(_addScoreAmount);
            
            Destroy(gameObject);
        }
    }
}