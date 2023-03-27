using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game;

/// <inheritdoc cref="EndangerEdDemo.Game.Screen.EndangerEdDemoGameScreen" />
/// <summary>
/// A screen for showing a loading screen on start playing.
/// </summary>
public partial class LoadingScreen : EndangerEdDemoGameScreen
{
    public override PresentationSlideNumber PresentationSlideNumber { get; set; } = PresentationSlideNumber.Slide3;

    private Box loadingBar;
    private const float loading_bar_height = 20;
    private EndangerEdDemoButton resetLoadingButton;
    private EndangerEdDemoButton finishLoadingButton;
    private EndangerEdDemoButton exitButton;
    private SpriteText loadingText;
    public bool FinishImmediately = false;

    [Resolved]
    private SessionStore sessionStore { get; set; }

    [Resolved]
    private AudioPlayer audioPlayer { get; set; }

    [Resolved]
    private Screenstack.EndangerEdDemoScreenStack screenStack { get; set; }

    private void onModeChanged(ValueChangedEvent<ScreenMode> screenModeChangedEvent)
    {
        updateButtonState(screenModeChangedEvent.NewValue);

        if (screenModeChangedEvent.NewValue == ScreenMode.Normal)
            FinishLoading();
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new Box()
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                RelativeSizeAxes = Axes.X,
                Height = loading_bar_height,
                Colour = Colour4.Black,
                Alpha = 0.5f
            },
            loadingBar = new Box()
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                RelativeSizeAxes = Axes.X,
                Height = loading_bar_height,
                Colour = Colour4.GreenYellow,
                Width = 0
            },
            exitButton = new EndangerEdDemoButton("Exit")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Width = 150,
                Height = 40,
                Margin = new MarginPadding
                {
                    Bottom = 130,
                    Right = 20
                },
                Action = () =>
                {
                    this.Exit();
                },
                Alpha = 0,
                Scale = new Vector2(2f)
            },
            resetLoadingButton = new EndangerEdDemoButton("Reset loading")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Width = 150,
                Height = 40,
                Margin = new MarginPadding
                {
                    Bottom = 80,
                    Right = 20
                },
                Action = () =>
                {
                    UpdateLoadingBar(0);
                    loadingText.Text = "Loading...";
                },
                Alpha = 0,
                Scale = new Vector2(2f)
            },
            finishLoadingButton = new EndangerEdDemoButton("Finish loading")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Width = 150,
                Height = 40,
                Margin = new MarginPadding
                {
                    Bottom = 30,
                    Right = 20
                },
                Action = FinishLoading,
                Alpha = 0,
                Scale = new Vector2(2f)
            },
            loadingText = new EndangerEdDemoSpriteText()
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Text = "Loading...",
                Margin = new MarginPadding
                {
                    Bottom = 30,
                    Left = 20
                }
            }
        };
        updateButtonState(sessionStore.ScreenMode.Value);
        sessionStore.ScreenMode.BindValueChanged(onModeChanged);
        FinishImmediately = sessionStore.ScreenMode.Value == ScreenMode.Normal;
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        base.OnEntering(e);
        audioPlayer.Pause();

        if (FinishImmediately)
        {
            FinishLoading();
        }
    }

    /// <summary>
    /// Update the loading bar.
    /// </summary>
    /// <param name="progress">Progress of the loading bar.</param>
    public void UpdateLoadingBar(float progress)
    {
        loadingBar.ResizeTo(new Vector2(progress, loading_bar_height), 1000, Easing.OutQuint);
    }

    /// <summary>
    /// Update the button state based on the <see cref="ScreenMode"/>
    /// </summary>
    /// <param name="screenMode">The current <see cref="ScreenMode"/></param>
    private void updateButtonState(ScreenMode screenMode)
    {
        if (screenMode == ScreenMode.Normal)
        {
            resetLoadingButton.FadeTo(0, 500, Easing.OutQuint);
            finishLoadingButton.FadeTo(0, 500, Easing.OutQuint);
            exitButton.FadeTo(0, 500, Easing.OutQuint);
        }
        else
        {
            resetLoadingButton.FadeTo(1, 500, Easing.OutQuint);
            finishLoadingButton.FadeTo(1, 500, Easing.OutQuint);
            exitButton.FadeTo(1, 500, Easing.OutQuint);
        }
    }

    /// <summary>
    /// Finish loading and go to the next screen.
    /// </summary>
    public void FinishLoading()
    {
        UpdateLoadingBar(1);
        this.Delay(1000).Then().Schedule(() =>
        {
            loadingText.Text = "Loading finished!";
        }).Delay(500).Then().Schedule(() =>
        {
            sessionStore.StartGame();
            sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide4;
        });
    }
}
