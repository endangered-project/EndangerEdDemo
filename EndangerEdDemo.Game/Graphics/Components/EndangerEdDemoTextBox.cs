using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics.UserInterface;

namespace EndangerEdDemo.Game.Graphics.Components;

public partial class EndangerEdDemoTextBox : BasicTextBox
{
    protected virtual bool AllowUniqueCharacterSamples => true;

    protected override float LeftRightPadding => 10;

    private Sample hoverSample;
    private Sample clickSample;

    [BackgroundDependencyLoader]
    private void load(AudioManager audioManager)
    {
        hoverSample = audioManager.Samples.Get("hover.wav");
        clickSample = audioManager.Samples.Get("click.wav");
    }

    protected override void OnTextSelectionChanged(TextSelectionType selectionType)
    {
        base.OnTextSelectionChanged(selectionType);

        switch (selectionType)
        {
            case TextSelectionType.Character:
                hoverSample.Play();
                break;

            case TextSelectionType.Word:
                hoverSample.Play();
                break;

            case TextSelectionType.All:
                hoverSample.Play();
                break;
        }
    }
}
