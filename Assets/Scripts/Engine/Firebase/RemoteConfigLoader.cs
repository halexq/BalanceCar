using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using UnityEngine;

namespace Engine.Firebase
{
    public class RemoteConfigLoader
    {
        public const string BackgroundColorKey = "back_color";
        public const string DelayBeforeGameOverKey = "delay_before_gameover";
        
        public IDictionary<string, ConfigValue> Config
        {
            get;
            private set;
        }
        
        public async Task Initialize()
        {
            await FetchDataAsync();
        }
        
        public async Task FetchDataAsync() 
        {
            var fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);

            await fetchTask.ContinueWithOnMainThread(FetchComplete);
        }
        
        private void FetchComplete(Task fetchTask) 
        {
            if (!fetchTask.IsCompleted) 
            {
                Debug.LogError("Retrieval hasn't finished.");
                return;
            }

            var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
            var info = remoteConfig.Info;
            if (info.LastFetchStatus != LastFetchStatus.Success) 
            {
                Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                return;
            }

            // Fetch successful. Parameter values must be activated to use.
            remoteConfig.ActivateAsync()
                .ContinueWithOnMainThread((task) => { Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}."); });

            Config = remoteConfig.AllValues;
        }
    }
}