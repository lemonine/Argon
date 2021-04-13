using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Argon.Components;

namespace Argon.Graphics
{
    /// <summary>
    /// Represents an outline mask to be drawn behind a <see cref="CSprite"/>. Directional values determine
    /// whether or not a mask should be offset in that direction.
    /// </summary>
    public struct SpriteOutline
    {
        public Color color;
        public bool left;
        public bool up;
        public bool right;
        public bool down;
        public bool upLeft;
        public bool upRight;
        public bool downLeft;
        public bool downRight;
        public bool active;

        /// <summary>
        /// An inactive <see cref="SpriteOutline"/> that does not draw a mask in any direction.
        /// </summary>
        public static SpriteOutline Invisible
        {
            get
            {
                return new SpriteOutline(
                    Color.Black,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false);
            }
        }
        /// <summary>
        /// A black <see cref="SpriteOutline"/> that draws a mask in four cardinal directions.
        /// </summary>
        public static SpriteOutline Circle
        {
            get
            {
                return new SpriteOutline(
                    Color.Black,
                    true,
                    true,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false);
            }
        }
        /// <summary>
        /// A black <see cref="SpriteOutline"/> that draws a mask in four cardinal directions and four diagonal directions.
        /// </summary>
        public static SpriteOutline Square
        {
            get
            {
                return new SpriteOutline(
                    Color.Black,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true);
            }
        }
        /// <summary>
        /// Returns a <see cref="List{Vector2}"/> based on this <see cref="SpriteOutline"/>'s direction fields.
        /// </summary>
        public List<Vector2> MaskOffsets
        {
            get
            {
                List<Vector2> offsets = new List<Vector2>();

                if (left)
                {
                    offsets.Add(Directions.Left);
                }
                if (up)
                {
                    offsets.Add(Directions.Up);
                }
                if (right)
                {
                    offsets.Add(Directions.Right);
                }
                if (down)
                {
                    offsets.Add(Directions.Down);
                }
                if (upLeft)
                {
                    offsets.Add(Directions.UpLeft);
                }
                if (upRight)
                {
                    offsets.Add(Directions.UpRight);
                }
                if (downLeft)
                {
                    offsets.Add(Directions.DownLeft);
                }
                if (downRight)
                {
                    offsets.Add(Directions.DownRight);
                }

                return offsets;
            }
        }

        public SpriteOutline(
            Color color,
            bool left,
            bool up,
            bool right,
            bool down,
            bool upLeft,
            bool upRight,
            bool downLeft,
            bool downRight,
            bool active = true)
        {
            this.color = color;
            this.left = left;
            this.up = up;
            this.right = right;
            this.down = down;
            this.upLeft = upLeft;
            this.upRight = upRight;
            this.downLeft = downLeft;
            this.downRight = downRight;
            this.active = active;
        }
    }
}
