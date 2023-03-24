using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace EndangerEdDemo.Game.Tests.Visual.Screens.Game
{
    public partial class TestSceneMainScreen : EndangerEdDemoTestScene
    {
        [Cached]
        private AudioPlayer audioPlayer = new AudioPlayer("matsuri.mp3");

        [Cached]
        private SessionStore sessionStore = new SessionStore();

        [Resolved]
        private AudioManager audioManager { get; set; }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            Dependencies.CacheAs(audioPlayer);
            Dependencies.CacheAs(sessionStore);
            audioPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(audioPlayer.TrackName.Value));
        }

        protected override void LoadAsyncComplete()
        {
            Add(new ScreenStack(new MainMenuScreen()) { RelativeSizeAxes = Axes.Both });
        }

        [SetUp]
        public void SetUp()
        {
            AddStep("play track", () => audioPlayer.Play());
            AddStep("pause track", () => audioPlayer.Pause());
        }
    }
}
