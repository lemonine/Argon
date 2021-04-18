using System;
using Microsoft.Xna.Framework;

namespace Argon
{
    /// <summary>
    /// Describes a circle.
    /// </summary>
    public struct Circle
    {
        public float X;
        public float Y;
        public float radius;

        /// <summary>
        /// The center of this <see cref="Circle"/>.
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return new Vector2(X, Y);
            }
        }
        /// <summary>
        /// A <see cref="Rectangle"/> that represents the bounds of this <see cref="CColiderCircle"/>.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)(X - radius),
                    (int)(Y - radius),
                    (int)Diameter,
                    (int)Diameter);
            }
        }
        /// <summary>
        /// The diameter of this <see cref="Circle"/>.
        /// </summary>
        public float Diameter
        {
            get
            {
                return radius * 2;
            }
        }
        /// <summary>
        /// The area of this <see cref="Circle"/>.
        /// </summary>
        public float Area
        {
            get
            {
                return MathF.Pow(radius, 2) * MathF.PI;
            }
        }

        public Circle(float X, float Y, float radius)
        {
            this.X = X;
            this.Y = Y;
            this.radius = radius;
        }

        public Circle(Vector2 center, float radius)
        {
            X = center.X;
            Y = center.Y;
            this.radius = radius;
        }

        /// <summary>
        /// Returns whether or not <paramref name="point"/> falls entirely within this <see cref="Circle"/>.
        /// </summary>
        /// <param name="point">The <see cref="Vector2"/> to check.</param>
        public bool Contains(Vector2 point)
        {
            return Vector2.Distance(Center, point) < radius;
        }

        /// <summary>
        /// Returns whether or not <paramref name="point"/> falls entirely within this <see cref="Circle"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> to check.</param>
        public bool Contains(Point point)
        {
            return Contains(point.ToVector2());
        }

        /// <summary>
        /// Returns whether or not <paramref name="rectangle"/> falls entirely within this <see cref="Circle"/>.
        /// </summary>
        /// <param name="rectangle">The <see cref=" Rectangle"/> to check.</param>
        public bool Contains(Rectangle rectangle)
        {
            int corners = 0;

            foreach (Point corner in rectangle.GetCorners())
            {
                if (Contains(corner))
                {
                    corners++;
                }
            }

            return corners == 4;
        }

        /// <summary>
        /// Returns whether or not <paramref name="circle"/> falls entirely within this <see cref="Circle"/>.
        /// </summary>
        /// <param name="circle"></param>
        public bool Contains(Circle circle)
        {
            return Vector2.Distance(Center, circle.Center) + circle.radius > radius;
        }

        /// <summary>
        /// Returns whether or not <paramref name="rectangle"/> overlaps with this <see cref="Circle"/>.
        /// </summary>
        /// <param name="rectangle"></param>
        public bool Overlaps(Rectangle rectangle)
        {
            return true;
        }

        /// <summary>
        /// Returns whether or not <paramref name="circle"/> overlaps with this <see cref="Circle"/>.
        /// </summary>
        /// <param name="circle"></param>
        public bool Overlaps(Circle circle)
        {
            return Vector2.Distance(Center, circle.Center) < radius + circle.radius;
        }
    }
}
