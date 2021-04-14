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

        /// <summary>
        /// The amount of <see cref="Color"/>s in this <see cref="Palette"/>.
        /// </summary>
        public int Size
        {
            get { return colors.Length - 1; }
        }

        public Palette(Texture2D texture)
        {
            colors = texture.GetColorData();
        }
    }
}
