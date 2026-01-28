using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Game.MissileLauncher
{
    public class MissileSpawner : MonoBehaviour
    {
        [SerializeField] private MissileNotifier _notifier;
        [SerializeField] private string _missileAddress;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _defaultSpawnCooldown;
        [SerializeField] private float _launchCooldown;
        
        // Loaded from Addressables.
        private Missile _missilePrefab;

        private float _time;
        private float _currentSpawnCooldown;
        private float _lastSpawnTime;

        private async void Awake()
        {
            try
            {
                _currentSpawnCooldown = GetRandomCooldown();

                var missileGameObjectPrefab = await Addressables.LoadAssetAsync<GameObject>(_missileAddress);
                _missilePrefab = missileGameObjectPrefab.GetComponent<Missile>();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
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