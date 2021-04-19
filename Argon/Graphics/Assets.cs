using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Argon.Graphics;

namespace Argon
{
    /// <summary>
    /// Contains assets for <see cref="Argon"/>.
    /// </summary>
    public static class Assets
    {
        public static Texture2D pixelTexture;

        public static void Load(GraphicsDevice graphicsDevice)
        {
            pixelTexture = graphicsDevice.CreatePixelTexture();
        }
    }
}
