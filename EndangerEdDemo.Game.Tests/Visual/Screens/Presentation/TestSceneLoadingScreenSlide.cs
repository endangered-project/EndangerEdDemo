using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen;
using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Presentation;

public partial class TestSceneLoadingScreenSlide : EndangerEdDemoTestScene
{
    private EndangerEdDemoScreenStack mainScreenStack;

    [Cached]
    private AudioPlayer audioPlayer = new AudioPlayer("dota.mp3");

    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Resolved]
    private AudioManager audioManager { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(audioPlayer);
        Dependencies.CacheAs(sessionStore);
        audioPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(audioPlayer.TrackName.Value));
        Add(mainScreenStack = new EndangerEdDemoScreenStack()
        {
            RelativeSizeAxes = Axes.Both
        });
        Dependencies.CacheAs(mainScreenStack);
        Add(new SwapModeButton());
        mainScreenStack.GameScreenStack.Push(new LoadingScreen());
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("switch mode", () => sessionStore.SwitchScreenMode());
        AddStep("play track", () => audioPlayer.Play());
        AddStep("pause track", () => audioPlayer.Pause());
    }
}
