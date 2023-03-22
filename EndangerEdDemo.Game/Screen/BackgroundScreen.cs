using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Video;

namespace EndangerEdDemo.Game.Screen;

public partial class BackgroundScreen : EndangerEdDemoScreen
{
    private Video video;

    [BackgroundDependencyLoader]
    private void load()
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
    }
}
