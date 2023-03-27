using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Game
{
    public partial class TestSceneMainScreen : EndangerEdDemoTestScene
    {
        [Cached]
        private AudioPlayer audioPlayer = new AudioPlayer("matsuri.mp3");

        [Cached]
        private SessionStore sessionStore = new SessionStore();

        [Cached]
        private GameSessionStore gameSessionStore = new GameSessionStore();

        [Resolved]
        private AudioManager audioManager { get; set; }

        private EndangerEdDemoScreenStack mainScreenStack;

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            Dependencies.CacheAs(audioPlayer);
            Dependencies.CacheAs(sessionStore);
            Dependencies.CacheAs(gameSessionStore);
            audioPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(audioPlayer.TrackName.Value));
        }

        protected override void LoadAsyncComplete()
        {
            Add(mainScreenStack = new EndangerEdDemoScreenStack { RelativeSizeAxes = Axes.Both });
            Dependencies.CacheAs(mainScreenStack);
            mainScreenStack.GameScreenStack.Push(new MainMenuScreen());
        }

        [SetUp]
        public void SetUp()
        {
            AddStep("pause track", () => audioPlayer.Pause());
            AddStep("play track", () => audioPlayer.Play());
        }
    }
}
