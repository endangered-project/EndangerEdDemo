using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;

namespace EndangerEdDemo.Game.Store;

public class EndangerEdDemoTextureStore : LargeTextureStore
{
    public EndangerEdDemoTextureStore(IRenderer renderer, IResourceStore<TextureUpload> store) : base(renderer, store)
    {
    }
}
