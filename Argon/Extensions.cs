using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon
{
    /// <summary>
    /// Extends varioius <see cref="Microsoft.Xna.Framework"/> (XNA)
    /// and <see cref="System"/> (.NET) classes and structs.
    /// </summary>
    public static class Extensions
    {
        #region float extensions
        /// <summary>
        /// Converts <paramref name="angle"/> to a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="angle">This <see cref="Single"/></param>
        public static Vector2 ToVector2(this float angle)
        {
            return new Vector2(MathF.Cos(angle), (float)MathF.Sin(angle));
        }
        #endregion
        #region Vector2 extensions
        /// <summary>
        /// Converts <paramref name="vector"/> to an angle.
        /// </summary>
        /// <param name="vector">This <see cref="Vector2"/> instance.</param>
        public static float ToAngle(this Vector2 vector)
        {
            return -MathF.Atan2(vector.X, vector.Y) % MathHelper.TwoPi;
        }

        /// <summary>
        /// Normalizes this <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector">This <see cref="Vector2"/> instance.</param>
        /// <returns></returns>
        public static Vector2 Normalized(this Vector2 vector)
        {
            return Vector2.Normalize(vector);
        }
        #endregion
        #region Rectangle extensions
        /// <summary>
        /// Returns an array of <see cref="Point"/>s representing the conrers of <paramref name="rectangle"/>.
        /// </summary>
        /// <param name="rectangle">This <see cref="Rectangle"/> instance.</param>
        /// <returns></returns>
        public static Point[] GetCorners(this Rectangle rectangle)
        {
            return new Point[]
            {
                new Point(rectangle.Left, rectangle.Top),
                new Point(rectangle.Right, rectangle.Top),
                new Point(rectangle.Left, rectangle.Bottom),
                new Point(rectangle.Right, rectangle.Bottom)
            };
        }
        #endregion
        #region Random (class) extensions
        /// <summary>
        /// Returns -1 or 1.
        /// </summary>
        /// <param name="random">This <see cref="Random"/> instance.</param>
        /// <returns></returns>
        public static sbyte NextSign(this Random random)
        {
            return (sbyte)(random.Next(2) == 0 ? -1 : 1);
        }

        /// <summary>
        /// Returns a single-precision floating-point number.
        /// </summary>
        /// <param name="random">This <see cref="Random"/> instance.</param>
        /// <returns></returns>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }
        #endregion
        #region Texture2D extensions
        /// <summary>
        /// Returns <paramref name="texture"/>'s <see cref="Color"/> at <paramref name="index"/>.
        /// </summary>
        /// <param name="texture">This <see cref="Texture2D"/> instance.</param>
        /// <param name="index">The index to return the <see cref="Color"/> of.</param>
        /// <returns></returns>
        public static Color GetColorData(this Texture2D texture, int index)
        {
            Color[] data = new Color[texture.Width * texture.Height];
            texture.GetData(data);

            return data[index];
        }

        /// <summary>
        /// Sets <paramref name="texture"/>'s <see cref="Color"/> at <paramref name="index"/> to <paramref name="color"/>.
        /// </summary>
        /// <param name="texture">This <see cref="Texture2D"/> instance.</param>
        /// <param name="index">The index to return the <see cref="Color"/> of.</param>
        /// <param name="color">The <see cref="Color"/> to set <paramref name="texture"/>'s data index.</param>
        public static void SetColorData(this Texture2D texture, int index, Color color)
        {
            Color[] data = new Color[texture.Width * texture.Height];
            texture.GetData(data);
            data[index] = color;
            texture.SetData(data);
        }

        /// <summary>
        /// Returns a blank mask of <paramref name="texture"/>. TODO - Do on gpu.
        /// </summary>
        /// <param name="texture">This <see cref="Texture2D"/> instance.</param>
        /// <param name="graphicsDevice">The active <see cref="GraphicsDevice"/>.</param>
        /// <returns></returns>
        public static Texture2D GetMask(this Texture2D texture, GraphicsDevice graphicsDevice)
        {
            Color[] maskData = new Color[texture.Width * texture.Height];
            Texture2D maskTexture = new Texture2D(graphicsDevice, texture.Width, texture.Height);

            for (int i = 0; i < texture.Width * texture.Height; i++)
            {
                if (texture.GetColorData(i) != Color.Transparent)
                {
                    maskData[i] = Color.White;
                }
            }

            maskTexture.SetData(maskData);
            return maskTexture;
        }
        #endregion
    }
}
