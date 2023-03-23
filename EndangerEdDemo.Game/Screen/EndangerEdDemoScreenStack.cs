using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

/// <summary>
/// A main screen stack include the presentation screen and the game stack.
/// </summary>
public partial class EndangerEdDemoScreenStack : ScreenStack
{
    [Resolved]
    private SessionStore sessionStore { get; set; }

    public EndangerEdDemoGameScreenStack gameScreenStack;

    /// <summary>
    ///
    /// </summary>
    /// <param name="screenModeChangedEvent"></param>
    private void onModeChanged(ValueChangedEvent<ScreenMode> screenModeChangedEvent)
    {
        if (screenModeChangedEvent.NewValue == ScreenMode.Normal)
        {
            gameScreenStack.ScaleTo(1f, 500, Easing.OutQuint);
        }
        else
        {
            gameScreenStack.ScaleTo(0.6f, 500, Easing.OutQuint);
        }
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        sessionStore.ScreenMode.BindValueChanged(onModeChanged);
    }

    public EndangerEdDemoScreenStack()
    {
        InternalChildren = new Drawable[]
        {
            new BackgroundScreen()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            },
            new Box()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Black,
                Alpha = 0.8f
            },
            gameScreenStack = new EndangerEdDemoGameScreenStack
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            }
        };
    }
}
