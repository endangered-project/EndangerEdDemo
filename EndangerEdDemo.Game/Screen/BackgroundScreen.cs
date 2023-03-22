using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Video;

namespace EndangerEdDemo.Game.Screen;

public partial class BackgroundScreen : EndangerEdDemoScreen
{
    private Video video;
    private Sprite background;

    [BackgroundDependencyLoader]
    private void load(TextureStore store)
    {
        InternalChildren = new Drawable[]
        {
            background = new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill,
                RelativeSizeAxes = Axes.Both,
                Texture = store.Get("background.jpg")
            },
            video = new Video("../../../../EndangerEdDemo.Resources/Videos/matsuri.mp4")
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Stretch,
                RelativeSizeAxes = Axes.Both,
                Loop = true,
                IsPlaying = true,
                Alpha = 0.5f
            }
        };
    }
}
