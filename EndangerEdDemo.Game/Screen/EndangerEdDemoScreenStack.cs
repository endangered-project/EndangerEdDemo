using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

public partial class EndangerEdDemoScreenStack : ScreenStack
{
    public EndangerEdDemoScreenStack()
    {
        InternalChild = new BackgroundScreen()
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
        };
    }
}
