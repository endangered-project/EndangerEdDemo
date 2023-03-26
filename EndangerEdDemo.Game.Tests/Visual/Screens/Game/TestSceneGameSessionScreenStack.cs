using EndangerEdDemo.Game.Screen;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Game;

public partial class TestSceneGameSessionScreenStack : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    public TestSceneGameSessionScreenStack()
    {
        Add(new EndangerEdDemoGameScreenStack());
    }
}
