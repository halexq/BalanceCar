using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.MissileLauncher
{
    public class MissileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _rocketPrefab;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _defaultSpawnCooldown;

        private float _time;
        private float _currentSpawnCooldown;
        private float _lastSpawnTime;

        private void Awake()
        {
            _currentSpawnCooldown = GetRandomCooldown();
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _currentSpawnCooldown && _time >= _lastSpawnTime + _currentSpawnCooldown)
            {
                SpawnRocket();

                _lastSpawnTime = _time;

                _currentSpawnCooldown = GetRandomCooldown();
            }
        }

        private void SpawnRocket()
        {
            var index = Random.Range(0, _spawnPoints.Count);
            Instantiate(_rocketPrefab, _spawnPoints[index].position, Quaternion.identity);
        }

        private float GetRandomCooldown()
        {
            return _defaultSpawnCooldown + Random.Range(-3f, 5f);
        }
    }
}