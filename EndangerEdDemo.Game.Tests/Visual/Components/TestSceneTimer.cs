using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Tests.Visual.Components;

[TestFixture]
public partial class TestSceneTimer : EndangerEdDemoTestScene
{
    [Cached]
    private SessionStore sessionStore = new SessionStore();

    [Cached]
    private GameSessionStore gameSessionStore = new GameSessionStore();

    private ScoreDisplay scoreDisplay;

    private SpriteText timeText;
    private SpriteText millisecondsText;
    private SpriteText rawTimeText;
    private SpriteText countdownText;

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(sessionStore);
        Dependencies.CacheAs(gameSessionStore);
    }

    public TestSceneTimer()
    {
        Add(new EndangerEdDemoGameScreenStack
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
        });
        Add(timeText = new SpriteText()
        {
            Anchor = Anchor.TopLeft,
            Origin = Anchor.TopLeft,
            RelativeSizeAxes = Axes.Both,
            Text = "Time : 0",
            Font = EndangerEdDemoFont.GetFont(size: 20, weight: EndangerEdDemoFont.FontWeight.Bold)
        });
        Add(millisecondsText = new SpriteText()
        {
            Anchor = Anchor.TopLeft,
            Origin = Anchor.TopLeft,
            Margin = new MarginPadding
            {
                Top = 30
            },
            RelativeSizeAxes = Axes.Both,
            Text = "Milliseconds : 0",
            Font = EndangerEdDemoFont.GetFont(size: 20, weight: EndangerEdDemoFont.FontWeight.Bold)
        });
        Add(rawTimeText = new SpriteText()
        {
            Anchor = Anchor.TopLeft,
            Origin = Anchor.TopLeft,
            Margin = new MarginPadding
            {
                Top = 60
            },
            RelativeSizeAxes = Axes.Both,
            Text = "Milliseconds : 0",
            Font = EndangerEdDemoFont.GetFont(size: 20, weight: EndangerEdDemoFont.FontWeight.Bold)
        });
        Add(countdownText = new SpriteText()
        {
            Anchor = Anchor.TopLeft,
            Origin = Anchor.TopLeft,
            Margin = new MarginPadding
            {
                Top = 90
            },
            RelativeSizeAxes = Axes.Both,
            Text = "Countdown : 0",
            Font = EndangerEdDemoFont.GetFont(size: 20, weight: EndangerEdDemoFont.FontWeight.Bold)
        });
    }

    [Test]
    public void TestScoreDisplayNumber()
    {
        AddStep("start timer", () => gameSessionStore.StopwatchClock.Start());
        AddStep("stop timer", () => gameSessionStore.StopwatchClock.Stop());
        AddStep("reset timer", () => gameSessionStore.StopwatchClock.Reset());
        AddSliderStep<float>("rate", 0f, 1f, 1f, value => gameSessionStore.StopwatchClock.Rate = value);
    }

    protected override void Update()
    {
        base.Update();
        // show time in minutes, seconds
        // also add 0 to seconds if seconds or minutes is less than 10
        timeText.Text = $"Time : {gameSessionStore.StopwatchClock.Elapsed.Minutes}:{(gameSessionStore.StopwatchClock.Elapsed.Seconds < 10 ? "0" : "")}{gameSessionStore.StopwatchClock.Elapsed.Seconds}";
        // show full milliseconds
        millisecondsText.Text = $"Milliseconds : {gameSessionStore.StopwatchClock.Elapsed.Milliseconds}";
        // show raw time
        rawTimeText.Text = $"Raw Time : {gameSessionStore.StopwatchClock}";
        // Calculate countdown
        string countdown = "";
        // Time per game is in milliseconds
        const int totalTime = GameSessionStore.TIME_PER_GAME / 1000;
        int timeLeft = totalTime - (int)gameSessionStore.StopwatchClock.Elapsed.TotalSeconds;

        // If time left is less than 0, set it to 0
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        // Calculate minutes left
        int minutesLeft = timeLeft / 60;
        // Calculate seconds left
        int secondsLeft = timeLeft % 60;
        // Add 0 to seconds if seconds or minutes is less than 10
        countdown += $"{minutesLeft}:{(secondsLeft < 10 ? "0" : "")}{secondsLeft}";
        countdownText.Text = $"Countdown : {countdown}";

        // If time left is less than 10, change color to red
        if (timeLeft < 10)
        {
            countdownText.Colour = Colour4.Red;
        }
        else
        {
            countdownText.Colour = Colour4.White;
        }

        countdownText.Text = $"Countdown : {countdown}";
    }
}
