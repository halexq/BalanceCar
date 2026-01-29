using System;
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

        public void Die()
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