using Engine.Firebase;
using Engine.UnityServices;
using VContainer;
using VContainer.Unity;

namespace Engine.DI
{
    public class CoreScope : LifetimeScope
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);

            base.Awake();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Bootstrap>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<FirebaseRemoteConfigLoader>(Lifetime.Singleton).AsSelf();
            builder.Register<UnityRemoteConfigLoader>(Lifetime.Singleton).AsSelf();
        }
    }
}