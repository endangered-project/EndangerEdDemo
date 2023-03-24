using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen;

public partial class EndangerEdDemoGameScreen : EndangerEdDemoScreen, IEndangerEdDemoGameScreen
{
    public virtual PresentationSlideNumber PresentationSlideNumber { get; set; } = PresentationSlideNumber.Slide0;

    [Resolved]
    private SessionStore sessionStore { get; set; }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        base.OnEntering(e);
        sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber;
    }
}
