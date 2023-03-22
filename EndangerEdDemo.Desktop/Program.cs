using osu.Framework.Platform;
using osu.Framework;
using EndangerEdDemo.Game;

namespace EndangerEdDemo.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"EndangerEdDemo"))
            using (osu.Framework.Game game = new EndangerEdDemoGame())
                host.Run(game);
        }
    }
}
