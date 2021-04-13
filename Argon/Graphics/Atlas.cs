using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon.Graphics
{
    /// <summary>
    /// Contains a <see cref="Texture2D"/> as well as an array of source <see cref="Rectangle"/>s.
    /// An <see cref="Atlas"/> can be used as data to draw a <see cref="Argon.Components.CSprite"/>.
    /// </summary>
    public class Atlas
    {
        public Texture2D texture;
        public Rectangle[] slices;

        public Atlas(Texture2D texture, Rectangle[] slices)
        {
            this.texture = texture;
            this.slices = slices;
        }

        public Atlas(Texture2D texture)
        {
            this.texture = texture;

            slices = new Rectangle[]
            {
                texture.Bounds
            };
        }
    }
}
