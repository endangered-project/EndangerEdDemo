using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen.Screenstack;

public partial class EndangerEdDemoGameScreenStack : ScreenStack
{
    [Resolved]
    private SessionStore sessionStore { get; set; }

    public EndangerEdDemoGameScreenStack()
    {
        InternalChildren = new Drawable[]
        {
            new BackgroundScreen()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            },
            new EndangerEdDemoGameSessionScreenStack()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            }
        };
    }
}
