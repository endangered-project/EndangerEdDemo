using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Screen.Presentation;

public partial class PresentationSlide1 : EndangerEdDemoPresentationScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Main Menu",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding(10),
            }
        };
    }
}
