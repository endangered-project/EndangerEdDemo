using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Logging;

namespace EndangerEdDemo.Game.Graphics.Components;

public partial class EndangerEdDemoButton : Button
{
    public string Text = "Button";
    private Colour4 buttonColor = Colour4.GreenYellow;

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new Container()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = 30,
                BorderColour = Colour4.White,
                BorderThickness = 5,
                Children = new Drawable[]
                {
                    new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = buttonColor
                    },
                    new SpriteText()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Text = Text,
                    }
                }
            }
        };
    }

    public EndangerEdDemoButton(string text)
    {
        Text = text;
    }

    protected override bool OnHover(HoverEvent e)
    {
        buttonColor = buttonColor.Darken(0.5f);
        Logger.L
        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        buttonColor = buttonColor.Lighten(0.5f);
        base.OnHoverLost(e);
    }

    protected override bool OnClick(ClickEvent e)
    {
        buttonColor = buttonColor.Darken(0.75f);
        return base.OnClick(e);
    }
}
