using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon.Graphics
{
    /// <summary>
    /// Stores an indexed color palette.
    /// </summary>
    public class Palette
    {
        public readonly Color[] colors;

        public Palette(Texture2D texture)
        {
            colors = texture.GetColorData();
        }
    }
}
