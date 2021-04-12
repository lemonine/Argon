using Argon.Components;

namespace Argon.Graphics
{
    /// <summary>
    /// Represents the type of outline to draw around a <see cref="CSprite"/>.
    /// </summary>
    public enum SpriteOutlineType
    {
        /// <summary>
        /// Fill Adjacent pixels.
        /// </summary>
        Circle,
        /// <summary>
        /// Fill Adjacent and diagonal pixels.
        /// </summary>
        Square
    }
}
