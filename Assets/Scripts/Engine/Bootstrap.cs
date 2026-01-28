using System.Threading;
using Cysharp.Threading.Tasks;
using Engine.Firebase;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Engine
{
    public class Bootstrap : IAsyncStartable
    {
        private readonly RemoteConfigLoader _remoteConfigLoader;

        public Bootstrap(RemoteConfigLoader remoteConfigLoader)
        {
            _remoteConfigLoader = remoteConfigLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _remoteConfigLoader.FetchDataAsync();

            SceneManager.LoadScene("Game");
        }
    }
}