using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Graphics.Components;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game.MicroGame;

public partial class TypeToAnswerMicroGameScreen : osu.Framework.Screens.Screen
{
    [BackgroundDependencyLoader]
    private void load(TextureStore store)
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "นี่คือสัตว์ชนิดใด ?",
                Margin = new MarginPadding
                {
                    Bottom = 400
                },
                Font = EndangerEdDemoFont.GetFont(size: 50, weight: EndangerEdDemoFont.FontWeight.Bold)
            },
            new Sprite()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = store.Get("blahaj.jpeg")
            },
            // Text input
            new EndangerEdDemoTextBox()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500, 50),
                CornerRadius = 20,
                Masking = true,
                Margin = new MarginPadding
                {
                    Bottom = -400
                }
            }
        };
    }
}
