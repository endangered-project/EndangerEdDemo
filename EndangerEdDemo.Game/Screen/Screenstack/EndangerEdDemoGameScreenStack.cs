using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Screen.Screenstack;

public partial class EndangerEdDemoGameScreenStack : ScreenStack
{
    public EndangerEdDemoGameSessionScreenStack GameSessionScreenStack;
    private ScreenStack menuScreenStack;

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
            menuScreenStack = new ScreenStack()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            },
            GameSessionScreenStack = new EndangerEdDemoGameSessionScreenStack()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            }
        };
    }

    protected override void LoadAsyncComplete()
    {
        base.LoadAsyncComplete();
        sessionStore.IsGameStarted.BindValueChanged(isGameStarted =>
        {
            Schedule(() =>
            {
                if (isGameStarted.NewValue)
                {
                    GameSessionScreenStack.Show();
                    menuScreenStack.Hide();
                }
                else
                {
                    GameSessionScreenStack.Hide();
                    menuScreenStack.Show();
                }
            });
        }, true);
    }

    /// <summary>
    /// Push the new <see cref="Screen"/> to the <see cref="menuScreenStack"/>.
    ///
    /// This will override the traditional <see cref="ScreenStack.Push"/> method.
    /// </summary>
    /// <param name="screen">A new screen to push</param>
    public void Push(osu.Framework.Screens.Screen screen)
    {
        menuScreenStack.Push(screen);
    }
}
