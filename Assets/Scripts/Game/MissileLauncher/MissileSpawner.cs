using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.MissileLauncher
{
    public class MissileSpawner : MonoBehaviour
    {
        [SerializeField] private MissileNotifier _notifier;
        [SerializeField] private Missile _missilePrefab;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _defaultSpawnCooldown;
        [SerializeField] private float _launchCooldown;

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
                SpawnMissile();

                _lastSpawnTime = _time;

                _currentSpawnCooldown = GetRandomCooldown();
            }
        }

        private void SpawnMissile()
        {
            var index = Random.Range(0, _spawnPoints.Count);

            var missile = Instantiate(_missilePrefab, _spawnPoints[index].position, Quaternion.identity);

            StartCoroutine(LaunchMissile(missile, index));
        }

        private float GetRandomCooldown()
        {
            return _defaultSpawnCooldown + Random.Range(-3f, 5f);
        }

        private IEnumerator LaunchMissile(Missile missile, int index)
        {
            _notifier.Activate(index);

            yield return new WaitForSeconds(_launchCooldown);

            _notifier.Deactivate(index);

            missile.Launch();
        }
    }
}