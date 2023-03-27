using osu.Framework.Bindables;

namespace EndangerEdDemo.Game.Store;

/// <summary>
/// A store that holds the current session state, will start initialized on DI.
/// </summary>
public class GameSessionStore
{
    public const int MAX_LIFE = 3;

    public BindableInt Life = new BindableInt(MAX_LIFE);

    public BindableInt Score = new BindableInt(0);

    /// <summary>
    /// Reset the game session to initial state.
    /// </summary>
    public void Reset()
    {
        Life.Value = MAX_LIFE;
        Score.Value = 0;
    }
}
