using osu.Framework.Bindables;
using osu.Framework.Logging;

namespace EndangerEdDemo.Game.Store;

/// <summary>
/// A store that holds the current session state.
/// </summary>
public class SessionStore
{
    public Bindable<ScreenMode> ScreenMode { get; } = new Bindable<ScreenMode>(Store.ScreenMode.Normal);

    public Bindable<PresentationSlideNumber> CurrentSlideNumber { get; } = new Bindable<PresentationSlideNumber>(PresentationSlideNumber.Slide0);

    /// <summary>
    /// Swap the current screen mode to the other one.
    /// </summary>
    public void SwapScreenMode()
    {
        ScreenMode.Value = ScreenMode.Value == Store.ScreenMode.Normal ? Store.ScreenMode.Presentation : Store.ScreenMode.Normal;
        Logger.Log($"🏬 Screen mode changed to {ScreenMode.Value}.");
    }
}
