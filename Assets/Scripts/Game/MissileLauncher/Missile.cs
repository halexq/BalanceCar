using UnityEngine;

namespace Game.MissileLauncher
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        public void Launch()
        {
            _rb.gravityScale = 1f;
        }

        public void Stop()
        {
            _rb.gravityScale = 0f;
            _rb.velocity = Vector2.zero;
        }
    }
}