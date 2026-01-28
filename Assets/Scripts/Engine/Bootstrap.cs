using System.Threading;
using Cysharp.Threading.Tasks;
using Engine.Firebase;
using Engine.UnityServices;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Engine
{
    public class Bootstrap : IAsyncStartable
    {
        private readonly FirebaseRemoteConfigLoader _firebaseRemoteConfigLoader;
        private readonly UnityRemoteConfigLoader _unityRemoteConfigLoader;

        public Bootstrap(FirebaseRemoteConfigLoader firebaseRemoteConfigLoader, UnityRemoteConfigLoader unityRemoteConfigLoader)
        {
            _firebaseRemoteConfigLoader = firebaseRemoteConfigLoader;
            _unityRemoteConfigLoader = unityRemoteConfigLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _firebaseRemoteConfigLoader.FetchDataAsync();
            await _unityRemoteConfigLoader.InitializeRemoteConfigAsync();

            SceneManager.LoadScene("Game");
        }
    }
}