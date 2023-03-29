using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Graphics.Components;

public partial class Timer : CompositeDrawable
{
    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    private SpriteText timerText;

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Time",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                Margin = new MarginPadding(10),
            },
            timerText = new SpriteText
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Text = gameSessionStore.Score.Value.ToString(),
                Font = new FontUsage(size:30),
                Margin = new MarginPadding
                {
                    Top = 40,
                    Left = 10,
                },
            }
        };
    }

    protected override void Update()
    {
        base.Update();
        // get time - TIME_PER_GAME
        long time = gameSessionStore.StopwatchClock.ElapsedMilliseconds - GameSessionStore.TIME_PER_GAME;

        // format : 00:00
        // add 0 if less than 10
        string minutes = (time / 1000 / 60).ToString();
        string seconds = (time / 1000 % 60).ToString();

        if (time / 1000 / 60 < 10)
        {
            minutes = "0" + minutes;
        }

        if (time / 1000 % 60 < 10)
        {
            seconds = "0" + seconds;
        }

        timerText.Text = minutes + ":" + seconds;
    }
}
