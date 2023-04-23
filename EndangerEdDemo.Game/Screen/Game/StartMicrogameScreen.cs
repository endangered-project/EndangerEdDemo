using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Screen.Game;

public partial class StartMicrogameScreen : osu.Framework.Screens.Screen
{
    [Resolved]
    private SessionStore sessionStore { get; set; }

    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Alpha = 0;
        InternalChildren = new Drawable[]
        {
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Game " + gameSessionStore.GameCount.Value + " started",
                Font = EndangerEdDemoFont.GetFont(size: 20, weight: EndangerEdDemoFont.FontWeight.Bold)
            }
        };
    }
}
