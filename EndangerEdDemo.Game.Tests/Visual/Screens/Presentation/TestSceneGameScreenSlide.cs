using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Screen.Game.MicroGame;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Presentation;

public partial class TestSceneGameScreenSlide : EndangerEdDemoTestScene
{
    [Cached]
    private AudioPlayer audioPlayer = new AudioPlayer("dota.mp3");

    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    [Cached]
    private EndangerEdDemoScreenStack mainScreenStack = new EndangerEdDemoScreenStack() { RelativeSizeAxes = Axes.Both };

    [Resolved]
    private AudioManager audioManager { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(audioPlayer);
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
        audioPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(audioPlayer.TrackName.Value));
        Add(mainScreenStack);
        Dependencies.CacheAs(mainScreenStack);
        Add(new SwapModeButton());
        mainScreenStack.GameScreenStack.Push(new MainMenuScreen());
        sessionStore.IsGameStarted.Value = true;
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide4;
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("switch mode", () => sessionStore.SwitchScreenMode());
        AddStep("play track", () => audioPlayer.Play());
        AddStep("pause track", () => audioPlayer.Pause());
        AddStep("switch logged in state", () => sessionStore.SwitchLoggedInState());
        AddStep("switch game started state", () =>
        {
            if (sessionStore.IsGameStarted.Value)
            {
                sessionStore.IsGameStarted.Value = false;
                Schedule(() => sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide1);
            }
            else
            {
                sessionStore.IsGameStarted.Value = true;
                Schedule(() => sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide4);
            }
        });
        AddStep("invoke startgame", () => gameSessionStore.StartGame());
        AddStep("push game screen", () => mainScreenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(new SelectNameMicroGameScreen()));
    }
}
