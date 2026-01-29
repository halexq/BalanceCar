using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Spawning.Interface;
using Game.Spawning.Type;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace Game.Spawning.Factory
{
    public class LaunchableFactory : IAsyncStartable
    {
        private const string MissileAddress = "Missile";
        private const string CoinAddress = "Coin";
        
        private readonly Dictionary<SpawnableType, string> _prefabAddresses = new()
        {
            { SpawnableType.Missile, MissileAddress },
            { SpawnableType.Coin, CoinAddress }
        };
        
        private readonly Dictionary<SpawnableType, GameObject> _prefabs = new();

        private readonly IObjectResolver _objectResolver;

        public LaunchableFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        // TODO: use IInitializable to prevent attempts to Create object before init but it will be synchronous.
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            // Fill dict of prefabs.
            foreach (var kvp in _prefabAddresses)
            {
                var prefab = await Addressables.LoadAssetAsync<GameObject>(kvp.Value);

                _prefabs.Add(kvp.Key, prefab);
            }
        }

        public ILaunchable Create(SpawnableType type, Vector3 position)
        {
            var spawnedObject = _objectResolver.Instantiate(_prefabs[type], position, Quaternion.identity);

            _objectResolver.InjectGameObject(spawnedObject);

            return spawnedObject.GetComponent<ILaunchable>();
        }
    }
}