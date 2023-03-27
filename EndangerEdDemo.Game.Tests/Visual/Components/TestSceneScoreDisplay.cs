using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace EndangerEdDemo.Game.Tests.Visual.Components;

[TestFixture]
public partial class TestSceneScoreDisplay : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    private ScoreDisplay scoreDisplay;

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
    }

    public TestSceneScoreDisplay()
    {
        Add(new EndangerEdDemoGameScreenStack
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
        });
        Add(scoreDisplay = new ScoreDisplay()
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
        });
    }

    [Test]
    public void TestScoreDisplayNumber()
    {
        AddSliderStep("Score", 0, 100000, 100, value => gameSessionStore.Score.Value = value);
    }
}
