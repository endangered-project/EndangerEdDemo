using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Screen.Presentation;

public partial class PresentationSlide2 : EndangerEdDemoPresentationScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Loading screen before the game starts",
                Font = new FontUsage(size: 50),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "2",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(10),
            }
        };
    }
}
