using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;

namespace EndangerEdDemo.Game.Tests.Visual
{
    public partial class TestSceneMainScreen : EndangerEdDemoTestScene
    {
        [Cached]
        private AudioPlayer audioPlayer = new AudioPlayer("matsuri.mp3");

        [Resolved]
        private AudioManager audioManager { get; set; }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            Dependencies.CacheAs(audioPlayer);
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
