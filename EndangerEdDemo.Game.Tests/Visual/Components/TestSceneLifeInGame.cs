using System.Linq;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Testing;

namespace EndangerEdDemo.Game.Tests.Visual.Components;

[TestFixture]
public partial class TestSceneLifeInGame : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    private LifeInGame lifeInGame;

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
    }

    public TestSceneLifeInGame()
    {
        Add(new EndangerEdDemoGameScreenStack());
        Add(lifeInGame = new LifeInGame());
    }

    [Test]
    public void TestLifeInGame()
    {
        AddStep("Show", () => this.ChildrenOfType<LifeInGame>().First().Show());
        AddStep("Hide", () => this.ChildrenOfType<LifeInGame>().First().Hide());
    }

    [Test]
    public void TestLifeInGameNumber()
    {
        AddSliderStep("Life", 0, 20, 3, value => gameSessionStore.Life.Value = value);
        AddStep("remove one heart", () => gameSessionStore.Life.Value -= 1);
    }
}
