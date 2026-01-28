using Game.Core;
using Game.Score;
using VContainer;
using VContainer.Unity;

namespace Engine.DI
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameRules>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerScore>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}