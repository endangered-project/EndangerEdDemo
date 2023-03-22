using EndangerEdDemo.Game.Screen;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using NUnit.Framework;

namespace EndangerEdDemo.Game.Tests.Visual
{
    [TestFixture]
    public partial class TestSceneMainScreen : EndangerEdDemoTestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        public TestSceneMainScreen()
        {
            Add(new ScreenStack(new MainMenuScreen()) { RelativeSizeAxes = Axes.Both });
        }
    }
}
