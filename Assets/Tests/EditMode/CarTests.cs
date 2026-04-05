using Game.Core;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class CarTests
    {
        private GameObject _gameObject;
        private Car _car;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject("CarTestObject");
            _car = _gameObject.AddComponent<Car>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_gameObject);
        }

        [Test]
        public void Die_RaisesDiedEventOnce()
        {
            var callCount = 0;

            Car.Died += OnDied;

            try
            {
                _car.Die();
                _car.Die();
            }
            finally
            {
                Car.Died -= OnDied;
            }

            Assert.That(callCount, Is.EqualTo(1));

            void OnDied()
            {
                callCount++;
            }
        }
    }
}
