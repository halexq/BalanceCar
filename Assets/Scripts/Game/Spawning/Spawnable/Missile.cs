using Game.Core;
using Game.Spawning.Interface;
using UnityEngine;

namespace Game.Spawning.Spawnable
{
    public class Missile : MonoBehaviour, ILaunchable
    {
        [SerializeField] private Rigidbody2D _rb;

        public void Launch()
        {
            _rb.gravityScale = 1f;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Car car))
            {
                return;
            }

            car.Die();

            Destroy(gameObject);
        }
    }
}