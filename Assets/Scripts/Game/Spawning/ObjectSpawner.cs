using System.Collections;
using System.Collections.Generic;
using Game.Spawning.Factory;
using Game.Spawning.Interface;
using Game.Spawning.Type;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Game.Spawning
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Inject] private LaunchableFactory _factory;
        
        [Header("Refs")]
        [SerializeField] private SpawnNotifier _notifier;
        [SerializeField] private List<Transform> _spawnPoints;
        
        [Header("Cooldown")]
        [SerializeField] private float _defaultSpawnCooldown;
        [SerializeField] private float _launchCooldown;
        private float _time;
        private float _currentSpawnCooldown;
        private float _lastSpawnTime;

        [Header("Chance")] 
        [SerializeField] private float _goodObjectChance = 0.3f;

        private void Start()
        {
            _currentSpawnCooldown = GetRandomCooldown();
        }
        
        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _currentSpawnCooldown && _time >= _lastSpawnTime + _currentSpawnCooldown)
            {
                SpawnObject();

                _lastSpawnTime = _time;

                _currentSpawnCooldown = GetRandomCooldown();
            }
        }

        private void SpawnObject()
        {
            var spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            
            var chance = Random.Range(0f, 1f);

            var spawnableType = chance <= _goodObjectChance ? SpawnableType.Coin : SpawnableType.Missile;

            var spawnedObject = _factory.Create(spawnableType, _spawnPoints[spawnPointIndex].position);

            StartCoroutine(LaunchObject(spawnedObject, spawnPointIndex, spawnableType));
        }

        private IEnumerator LaunchObject(ILaunchable launchable, int spawnPointIndex, SpawnableType type)
        {
            _notifier.Activate(spawnPointIndex, type);

            yield return new WaitForSeconds(_launchCooldown);

            _notifier.Deactivate(spawnPointIndex);

            launchable.Launch();
        }

        private float GetRandomCooldown()
        {
            return _defaultSpawnCooldown + Random.Range(-3f, 5f);
        }
    }
}