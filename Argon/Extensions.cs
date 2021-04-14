﻿using System;
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
    }
}
