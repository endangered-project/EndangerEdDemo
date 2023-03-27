using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace EndangerEdDemo.Game.Screen.Game;

/// <summary>
/// A welcome screen for the game to tell that this is a demo.
/// </summary>
public partial class WarningScreen : EndangerEdDemoGameScreen
{
    public override PresentationSlideNumber PresentationSlideNumber => PresentationSlideNumber.Slide0;

    private SpriteIcon warningSprite;

    private readonly osu.Framework.Screens.Screen nextScreen;

    private const float icon_y = -100f;

    [Resolved]
    private Screenstack.EndangerEdDemoScreenStack screenStack { get; set; }

    public WarningScreen(osu.Framework.Screens.Screen nextScreen)
    {
        this.nextScreen = nextScreen;
        ValidForResume = false;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new Container()
            {
                Colour = Color4Extensions.FromHex("73bfe9"),
                RelativeSizeAxes = Axes.Both,
                Alpha = 0.5f,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1.5f),
            },
            warningSprite = new SpriteIcon
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Icon = FontAwesome.Solid.Flask,
                Size = new Vector2(40),
                Y = icon_y,
                Colour = Color4.GreenYellow
            },
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Warning :",
                Font = new FontUsage(size: 30),
                Colour = Color4.GreenYellow,
                Y = -40f,
            },
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "This is a demo version of EndangerEd, all data in this game is mocked up.",
                Font = new FontUsage(size: 30),
                Colour = Color4.GreenYellow
            },
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "All session detail will be lost when you exit the game.",
                Font = new FontUsage(size: 30),
                Colour = Color4.GreenYellow,
                Y = 40f,
            }
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        if (nextScreen != null)
        {
            LoadComponentAsync(nextScreen);
        }
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        base.OnEntering(e);

        warningSprite.RotateTo(-10)
                     .MoveToY(icon_y - 30, 250, Easing.OutQuint)
                     .RotateTo(360, 750, Easing.OutQuint)
                     .Then()
                     .MoveToY(icon_y, 250, Easing.OutQuint);

        warningSprite.FlashColour(Color4Extensions.FromHex("ffffed"), 500, Easing.OutQuint).Loop();

        this.FadeInFromZero(500)
            .Then(5000)
            .FadeOut(250)
            .MoveToY(-200, 250, Easing.OutQuint)
            .Finally(next =>
            {
                if (nextScreen != null)
                    screenStack.GameScreenStack.Push(nextScreen);
            });
    }
}
