using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Graphics.Components;

/// <summary>
/// A <see cref="SpriteText"/> with a default font used in the game.
/// </summary>
public partial class EndangerEdDemoSpriteText : SpriteText
{
    public EndangerEdDemoSpriteText()
    {
        Font = EndangerEdDemoFont.Default;
        Shadow = true;
    }
}
