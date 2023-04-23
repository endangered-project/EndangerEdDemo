using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Game;

public partial class TestSceneGameSessionScreenStack : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
        sessionStore.IsGameStarted.Value = true;
    }

    public TestSceneGameSessionScreenStack()
    {
        Add(new EndangerEdDemoGameScreenStack());
        AddStep("start game", () => gameSessionStore.GameCount.Value = gameSessionStore.GameCount.Value + 1);
    }
}
