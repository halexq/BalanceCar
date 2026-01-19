using Game.Score;
using VContainer;
using VContainer.Unity;

namespace Engine.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<ScoreKeeper>(Lifetime.Singleton).As<IScoreSource>();
        }
    }
}