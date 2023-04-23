using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game;

public partial class StartMicrogameScreen : osu.Framework.Screens.Screen
{
    [Resolved]
    private SessionStore sessionStore { get; set; }

    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    private SpriteIcon icon;

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            icon = new SpriteIcon
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Icon = FontAwesome.Solid.Clock,
                Size = new Vector2(40),
                Y = -40,
                Colour = Colour4.GreenYellow
            },
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Game " + gameSessionStore.GameCount.Value + " started",
                Font = EndangerEdDemoFont.GetFont(size: 40, weight: EndangerEdDemoFont.FontWeight.Bold),
                Padding = new MarginPadding
                {
                    Top = 20
                }
            }
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        icon.FlashColour(Colour4.White, 500, Easing.OutQuint).RotateTo(360, 500, Easing.OutQuint).Loop();
    }
}
