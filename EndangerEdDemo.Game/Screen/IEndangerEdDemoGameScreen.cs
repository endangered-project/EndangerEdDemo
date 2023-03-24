using EndangerEdDemo.Game.Store;

namespace EndangerEdDemo.Game.Screen;

public interface IEndangerEdDemoGameScreen : IEndangerEdDemoScreen
{
    public PresentationSlideNumber PresentationSlideNumber { get; }
}
