using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon
{
    /// <summary>
    /// Extends varioius XNA and Dotnet classes and structs.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts <paramref name="angle"/> to a <see cref="Vector2"/>.
        /// </summary>
        public static Vector2 ToVector(this float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        /// <summary>
        /// Converts <paramref name="vector"/> to an angle.
        /// </summary>
        public static float ToAngle(this Vector2 vector)
        {
            return -(float)Math.Atan2(vector.X, vector.Y);
        }

        /// <summary>
        /// Draws a line from <paramref name="pointA"/> to <paramref name="pointB"/>, with a tint of <paramref name="color"/>,
        /// a width of <paramref name="width"/>, and a depth of <paramref name="layer"/>.
        /// </summary>
        /// <param name="spriteBatch">This <see cref="SpriteBatch"/> instance.</param>
        /// <param name="pointA">The start of this line</param>
        /// <param name="pointB">The end of this line.</param>
        /// <param name="color">The color of this line.</param>
        /// <param name="width">The width of this line.</param>
        /// <param name="layer">The depth of this line.</param>
        public static void DrawLine(
            this SpriteBatch spriteBatch,
            Vector2 pointA,
            Vector2 pointB,
            Color color,
            float width = 1,
            float layer = 0)
        {
            float rotation = (pointB - pointA).ToAngle();
            Vector2 origin = Vector2.UnitX / width * width;
            Vector2 scale = new Vector2(width, (pointB - pointA).Length());

            spriteBatch.Draw(
                Assets.pixelTexture,
                pointA,
                default,
                color,
                rotation,
                origin,
                scale,
                SpriteEffects.None,
                0);
        }
    }
}
