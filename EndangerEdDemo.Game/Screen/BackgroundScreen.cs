using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Video;

namespace EndangerEdDemo.Game.Screen;

public partial class BackgroundScreen : EndangerEdDemoScreen
{
    private Track track;
    private Video video;

    [BackgroundDependencyLoader]
    private void load(ITrackStore tracks)
    {
        InternalChildren = new Drawable[]
        {
            video = new Video("../../../../EndangerEdDemo.Resources/Videos/matsuri.mp4")
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Stretch,
                RelativeSizeAxes = Axes.Both,
                Loop = true,
                IsPlaying = true
            }
        };
        track = tracks.Get("matsuri.mp3");
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        track.Looping = true;
        track.Start();
    }
}
