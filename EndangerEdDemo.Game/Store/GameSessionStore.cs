using osu.Framework.Bindables;
using osu.Framework.Timing;

namespace EndangerEdDemo.Game.Store;

/// <summary>
/// A store that holds the current session state, will start initialized on DI.
/// </summary>
public class GameSessionStore
{
    public const int MAX_LIFE = 3;

    /// <summary>
    /// Time per microgame in milliseconds.
    /// </summary>
    public const int TIME_PER_GAME = 60000;

    public BindableInt Life = new BindableInt(MAX_LIFE);

    public BindableInt Score = new BindableInt(0);

    // We need to use StopwatchClock instead of Stopwatch because it's also depend on the frame time on framework too.
    public StopwatchClock StopwatchClock = new StopwatchClock();

    /// <summary>
    /// Reset the game session to initial state.
    /// </summary>
    public void Reset()
    {
        Life.Value = MAX_LIFE;
        Score.Value = 0;
        StopwatchClock.Reset();
    }
}
