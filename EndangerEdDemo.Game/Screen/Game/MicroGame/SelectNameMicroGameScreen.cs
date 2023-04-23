using EndangerEdDemo.Game.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game.MicroGame;

public partial class SelectNameMicroGameScreen : osu.Framework.Screens.Screen
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
                Text = "นี่คือสัตว์ชนิดใด ? (เลือกชื่อที่ถูกต้อง)",
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
            new FillFlowContainer()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Direction = FillDirection.Horizontal,
                AutoSizeAxes = Axes.Both,
                Spacing = new Vector2(30),
                Margin = new MarginPadding
                {
                    Bottom = -400
                },
                Children = new Drawable[]
                {
                    new Container()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(200, 50),
                        CornerRadius = 20,
                        Masking = true,
                        Children = new Drawable[]
                        {
                            new Box()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.Both,
                                Size = new Vector2(1),
                                Colour = Colour4.Red
                            },
                            new SpriteText()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Text = "1. ปลากระเบน",
                                Font = EndangerEdDemoFont.GetFont(size: 40, weight: EndangerEdDemoFont.FontWeight.Bold)
                            }
                        }
                    },
                    new Container()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(200, 50),
                        CornerRadius = 20,
                        Masking = true,
                        Children = new Drawable[]
                        {
                            new Box()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.Both,
                                Size = new Vector2(1),
                                Colour = Colour4.Green
                            },
                            new SpriteText()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Text = "2. ฉลาม",
                                Font = EndangerEdDemoFont.GetFont(size: 40, weight: EndangerEdDemoFont.FontWeight.Bold)
                            }
                        }
                    },
                    new Container()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(200, 50),
                        CornerRadius = 20,
                        Masking = true,
                        Children = new Drawable[]
                        {
                            new Box()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.Both,
                                Size = new Vector2(1),
                                Colour = Colour4.Blue
                            },
                            new SpriteText()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Text = "3. ปลากระพง",
                                Font = EndangerEdDemoFont.GetFont(size: 40, weight: EndangerEdDemoFont.FontWeight.Bold)
                            }
                        }
                    },
                }
            }
        };
    }
}
