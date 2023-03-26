using System;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Logging;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

/// <summary>
/// A main screen stack include the presentation screen and the game stack.
/// </summary>
public partial class EndangerEdDemoScreenStack : ScreenStack
{
    [Resolved]
    private SessionStore sessionStore { get; set; }

    public EndangerEdDemoGameScreenStack GameScreenStack;

    public ScreenStack PresentationScreenStack;

    /// <summary>
    /// A callback function that will be called when the screen mode changed.
    /// </summary>
    /// <param name="screenModeChangedEvent">A <see cref="ValueChangedEvent{ScreenMode}"/> that contains the new value.</param>
    private void onModeChanged(ValueChangedEvent<ScreenMode> screenModeChangedEvent)
    {
        if (screenModeChangedEvent.NewValue == ScreenMode.Normal)
        {
            GameScreenStack.ScaleTo(1f, 500, Easing.OutQuint);
            PresentationScreenStack.FadeTo(0f, 500, Easing.OutQuint);
        }
        else
        {
            GameScreenStack.ScaleTo(0.7f, 500, Easing.OutQuint);
            PresentationScreenStack.FadeTo(1f, 500, Easing.OutQuint);
        }
    }

    /// <summary>
    /// Change the current slide to the given <see cref="PresentationSlideNumber"/>.
    /// </summary>
    /// <param name="slideNumberChangedEvent">A <see cref="ValueChangedEvent{PresentationSlideNumber}"/> that contains the new value.</param>
    private void onSlideNumberChanged(ValueChangedEvent<PresentationSlideNumber> slideNumberChangedEvent)
    {
        PresentationScreenStack.Push(getSlideScreen(slideNumberChangedEvent.NewValue));
        Logger.Log($"📺 Pushed {slideNumberChangedEvent.NewValue} slide to the presentation screen stack.");
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        sessionStore.ScreenMode.BindValueChanged(onModeChanged);
        sessionStore.CurrentSlideNumber.BindValueChanged(onSlideNumberChanged);
        PresentationScreenStack.Push(getSlideScreen(PresentationSlideNumber.Slide0));
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
            GameScreenStack = new EndangerEdDemoGameScreenStack
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            },
            PresentationScreenStack = new ScreenStack
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Alpha = 0f
            }
        };
    }

    /// <summary>
    /// Return a new <see cref="EndangerEdDemoPresentationScreen"/> with the given <see cref="PresentationSlideNumber"/>.
    /// </summary>
    /// <param name="slideNumber">A target <see cref="slideNumber"/></param>
    /// <returns></returns>
    private EndangerEdDemoPresentationScreen getSlideScreen(PresentationSlideNumber slideNumber)
    {
        // find the class in the EndangerEdDemo.Game.Screen.Presentation namespace that has the name Presentation{slideNumber}
        var type = Type.GetType($"EndangerEdDemo.Game.Screen.Presentation.Presentation{slideNumber}");

        if (type is null)
        {
            throw new NullReferenceException($"Cannot find the type Presentation{slideNumber}.");
        }

        // return a new instance of the class
        return (EndangerEdDemoPresentationScreen)Activator.CreateInstance(type);
    }
}
