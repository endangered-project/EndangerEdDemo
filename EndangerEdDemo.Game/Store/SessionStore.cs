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

    public Bindable<bool> IsLoggedIn { get; } = new Bindable<bool>(false);

    /// <summary>
    /// Swap the current screen mode to the other one.
    /// </summary>
    public void SwitchScreenMode()
    {
        ScreenMode.Value = ScreenMode.Value == Store.ScreenMode.Normal ? Store.ScreenMode.Presentation : Store.ScreenMode.Normal;
        Logger.Log($"🏬 Screen mode changed to {ScreenMode.Value}.");
    }

    /// <summary>
    /// Swap the current logged in state to the other one.
    /// </summary>
    public void SwitchLoggedInState()
    {
        IsLoggedIn.Value = !IsLoggedIn.Value;
        Logger.Log($"🏬 Logged in state changed to {IsLoggedIn.Value}.");
    }
}
