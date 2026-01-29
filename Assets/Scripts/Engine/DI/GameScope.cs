using Game.Core;
using Game.Score;
using Game.Spawning.Factory;
using VContainer;
using VContainer.Unity;

namespace Engine.DI
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameRules>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<PlayerScore>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<LaunchableFactory>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        }
    }
}