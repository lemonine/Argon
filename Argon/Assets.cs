using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Argon
{
    /// <summary>
    /// Contains assets for <see cref="Argon"/>.
    /// </summary>
    public static class Assets
    {
        public static ContentManager content;

        public static Texture2D pixelTexture;

        public static void Load(ContentManager _content, GraphicsDevice graphicsDevice)
        {
            content = _content;

            pixelTexture = new Texture2D(graphicsDevice, 1, 1);
            pixelTexture.SetData(new Color[] { Color.White });
        }
    }
}
