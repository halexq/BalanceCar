using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace Engine.UnityServices
{
    public class UnityRemoteConfigLoader
    {
        public const string BackColorKey = "back_color";

        public JObject Config
        {
            get;
            private set;
        }

        public async UniTask InitializeRemoteConfigAsync()
        {
            if (!Utilities.CheckForInternetConnection())
            {
                return;
            }

            await Unity.Services.Core.UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
            await RemoteConfigService.Instance.FetchConfigsAsync(new UserAttributes(), new AppAttributes());
        }

        private void ApplyRemoteSettings(ConfigResponse configResponse)
        {
            Debug.Log("RemoteConfigService.Instance.appConfig fetched: " + RemoteConfigService.Instance.appConfig.config);

            Config = RemoteConfigService.Instance.appConfig.config;
        }

        private struct UserAttributes {}
        private struct AppAttributes {}
    }
}