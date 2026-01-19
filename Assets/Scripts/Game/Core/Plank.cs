using UnityEngine;

namespace Game.Core
{
    public class Plank : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _rotationSpeed;
        
        private float _input;
        
        private void Update()
        {
            _input = -Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            _rb.MoveRotation(_rb.rotation + _input * _rotationSpeed);
        }
    }
}
