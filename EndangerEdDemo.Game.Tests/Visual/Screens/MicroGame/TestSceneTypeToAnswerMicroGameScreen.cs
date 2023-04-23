using EndangerEdDemo.Game.Screen.Game.MicroGame;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.MicroGame;

public partial class TestSceneTypeToAnswerMicroGameScreen : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    private EndangerEdDemoGameScreenStack mainScreenStack = new EndangerEdDemoGameScreenStack();

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
        sessionStore.IsGameStarted.Value = true;
    }

    public TestSceneTypeToAnswerMicroGameScreen()
    {
        Add(mainScreenStack);
    }

    protected override void LoadAsyncComplete()
    {
        base.LoadAsyncComplete();
        mainScreenStack.GameSessionScreenStack.MainScreenStack.Push(new TypeToAnswerMicroGameScreen());
    }
}
