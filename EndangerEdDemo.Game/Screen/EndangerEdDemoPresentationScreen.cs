using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

public partial class EndangerEdDemoPresentationScreen : EndangerEdDemoScreen, IEndangerEdDemoPresentationScreen
{
    public EndangerEdDemoPresentationScreen()
    {
        RelativeSizeAxes = Axes.Both;
        Anchor = Anchor.Centre;
        Origin = Anchor.Centre;
        Position = new(100, 0);
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        base.OnEntering(e);
        this.FadeInFromZero(500, Easing.OutQuint)
            .MoveToX(0, 500, Easing.OutQuint);
    }

    public override void OnSuspending(ScreenTransitionEvent e)
    {
        base.OnSuspending(e);
        this.FadeOut(500, Easing.OutQuint)
            .MoveToX(-100, 500, Easing.OutQuint);
    }

    public override void OnResuming(ScreenTransitionEvent e)
    {
        base.OnResuming(e);
        this.MoveToX(-100, 0, Easing.OutQuint)
            .Then()
            .FadeIn(500, Easing.OutQuint)
            .MoveToX(0, 500, Easing.OutQuint);
    }
}
