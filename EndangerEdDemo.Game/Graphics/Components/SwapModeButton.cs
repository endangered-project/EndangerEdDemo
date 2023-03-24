using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace EndangerEdDemo.Game.Graphics.Components;

/// <summary>
/// A button live in left-bottom corner of the screen for changing between presentation mode and real screen mode.
/// </summary>
public partial class SwapModeButton : Button
{
    private Container scaleContainer;
    private Circle button;
    private SpriteIcon icon;

    [Resolved]
    private SessionStore sessionStore { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Anchor = Anchor.BottomLeft;
        Origin = Anchor.BottomLeft;
        Size = new Vector2(40);
        Position = new Vector2(20, -20);
        Action = sessionStore.SwapScreenMode;
        InternalChild = scaleContainer = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(40),
            Children = new Drawable[]
            {
                button = new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.AliceBlue,
                    BorderThickness = 10,
                    BorderColour = Color4.White,
                    Masking = true
                },
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Child = icon = new SpriteIcon
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Size = new Vector2(0.5f),
                        Icon = FontAwesome.Solid.Desktop,
                        Colour = Color4.Black
                    }
                }
            }
        };

        sessionStore.ScreenMode.BindValueChanged(mode =>
        {
            if (mode.NewValue == ScreenMode.Presentation)
            {
                icon.Icon = FontAwesome.Solid.Desktop;
            }
            else
            {
                icon.Icon = FontAwesome.Solid.Gamepad;
            }

            icon.Spin(250, RotationDirection.Clockwise, 0f, 1);
        }, true);
    }
}
