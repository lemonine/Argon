using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon.Graphics
{
    /// <summary>
    /// Stores a read-only indexed color palette.
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

        /// <summary>
        /// Converts <paramref name="texture"/> into a 1d <see cref="Color"/> array.
        /// </summary>
        /// <param name="texture">The <see cref="Texture2D"/> to extract colors from.</param>
        public Palette(Texture2D texture)
        {
            colors = texture.GetColorData();
        }
    }
}
