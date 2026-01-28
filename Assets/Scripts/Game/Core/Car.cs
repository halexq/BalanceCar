using System;
using Game.MissileLauncher;
using UnityEngine;

namespace Game.Core
{
    public class Car : MonoBehaviour
    {
        public static event Action Died;

        private bool _isAlive = true;

        private void Update()
        {
            if (transform.position.y < -3f)
            {
                Die();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Missile _))
            {
                return;
            }

            Die();
        }

        private void Die()
        {
            if (!_isAlive)
            {
                return;
            }
            
            _isAlive = false;
            
            Died?.Invoke();
        }
    }
}