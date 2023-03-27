using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Game;

[TestFixture]
public partial class TestSceneEndangerEdDemoWarningScreen : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private EndangerEdDemoScreenStack screenStack = new EndangerEdDemoScreenStack();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(screenStack);
        Dependencies.CacheAs(gameSessionStore);
    }

    [SetUp]
    public void SetUp()
    {
        Add(screenStack);
        screenStack.GameScreenStack.Push(new WarningScreen(null));
    }
}
