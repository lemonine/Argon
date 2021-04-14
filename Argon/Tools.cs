using Microsoft.Xna.Framework;

namespace Argon
{
    /// <summary>
    /// Provides varoius math tools.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Restricts <paramref name="vector"/> within <paramref name="bounds"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2"/> to clamp.</param>
        /// <param name="bounds">The bounds to restrict <paramref name="vector"/></param>
        public static void Clamp(ref Vector2 vector, Rectangle bounds)
        {
            vector = Clamp(vector, bounds);
        }

        /// <summary>
        /// Returns <paramref name="vector"/> restricted within <paramref name="bounds"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2"/> to clamp.</param>
        /// <param name="bounds">The bounds to restrict <paramref name="vector"/></param>
        public static Vector2 Clamp(Vector2 vector, Rectangle bounds)
        {
            if (!bounds.Contains(vector))
            {
                if (vector.X < bounds.Left)
                {
                    vector.X = bounds.Left;
                }
                if (vector.Y < bounds.Top)
                {
                    vector.Y = bounds.Top;
                }
                if (vector.X > bounds.Right)
                {
                    vector.X = bounds.X;
                }
                if (vector.Y > bounds.Bottom)
                {
                    vector.Y = bounds.Bottom;
                }
            }

            return vector;
        }

        /// <summary>
        /// Restricts <paramref name="rectangle"/> within <paramref name="bounds"/>.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle"/> to clamp.</param>
        /// <param name="bounds">The bounds to restrict <paramref name="rectangle"/>.</param>
        public static void Clamp(ref Rectangle rectangle, Rectangle bounds)
        {
            rectangle = Clamp(rectangle, bounds);
        }

        /// <summary>
        /// Returns <paramref name="rectangle"/> restricted within <paramref name="bounds"/>.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle"/> to clamp.</param>
        /// <param name="bounds">The bounds to restrict <paramref name="rectangle"/>.</param>
        public static Rectangle Clamp(Rectangle rectangle, Rectangle bounds)
        {
            if (!bounds.Contains(rectangle))
            {
                if (rectangle.Width < bounds.Width && rectangle.Height < bounds.Height)
                {
                    if (rectangle.Left < bounds.Left)
                    {
                        rectangle.X = bounds.Left;
                    }
                    if (rectangle.Top < bounds.Top)
                    {
                        rectangle.Y = bounds.Top;
                    }
                    if (rectangle.Right > bounds.Right)
                    {
                        rectangle.X = bounds.X - rectangle.Width;
                    }
                    if (rectangle.Bottom > bounds.Bottom)
                    {
                        rectangle.Y = bounds.Bottom - rectangle.Height;
                    }
                }
                else
                {
                    Debug.Log("The rectangle could not be clamped. Returning initial rectangle.");
                }
            }

            return rectangle;
        }
    }
}
