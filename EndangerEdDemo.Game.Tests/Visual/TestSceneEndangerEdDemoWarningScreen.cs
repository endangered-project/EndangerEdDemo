using EndangerEdDemo.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Tests.Visual;

[TestFixture]
public partial class TestSceneEndangerEdDemoWarningScreen : EndangerEdDemoTestScene
{
    [SetUp]
    public void SetUp()
    {
        Add(new ScreenStack(new WarningScreen(null))
        {
            RelativeSizeAxes = Axes.Both
        });
    }
}
