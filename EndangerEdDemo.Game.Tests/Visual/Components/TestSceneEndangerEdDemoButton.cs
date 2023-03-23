using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osuTK;

namespace EndangerEdDemo.Game.Tests.Visual.Components;

[TestFixture]
public partial class TestSceneEndangerEdDemoButton : EndangerEdDemoTestScene
{
    public TestSceneEndangerEdDemoButton()
    {
        Add(new EndangerEdDemoGameScreenStack());
        Add(new EndangerEdDemoButton("bruh")
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(220,100)
        });
    }
}
