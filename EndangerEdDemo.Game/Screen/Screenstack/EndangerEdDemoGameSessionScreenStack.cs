using EndangerEdDemo.Game.Graphics.Components;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Screenstack;

public partial class EndangerEdDemoGameSessionScreenStack : ScreenStack
{
    [BackgroundDependencyLoader]
    private void load(TextureStore store)
    {
        InternalChildren = new Drawable[]
        {
            new LifeInGame(),
            new EndangerEdDemoButton("End")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(10),
                Width = 80,
                Height = 50
            },
            new EndangerEdDemoButton("Start")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding
                {
                    Bottom = 70,
                    Right = 10
                },
                Width = 80,
                Height = 50
            },
            new Sprite
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                RelativeSizeAxes = Axes.Both,
                Size = new Vector2(0.875f, 0.875f),
                Margin = new MarginPadding(10),
                Name = "Mock screen",
                Texture = store.Get("background2.png")
            }
        };
    }
}
