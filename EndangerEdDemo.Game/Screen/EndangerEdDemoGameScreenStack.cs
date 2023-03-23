using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

public partial class EndangerEdDemoGameScreenStack : ScreenStack
{
    private Container borderBox;

    [Resolved]
    private SessionStore sessionStore { get; set; }

    public EndangerEdDemoGameScreenStack()
    {
        InternalChildren = new Drawable[]
        {
            // new box as a border
            borderBox = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Black,
                Alpha = 0.8f,
                Masking = true,
                CornerRadius = 10
            },
            new BackgroundScreen()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            }
        };
    }
}
