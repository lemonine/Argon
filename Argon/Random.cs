using Microsoft.Xna.Framework;
using Argon.Graphics;

namespace Argon
{
    /// <summary>
    /// Provides methods for generating random values.
    /// </summary>
    public static class Random
    {
        private static System.Random random;

        static Random()
        {
            random = new System.Random(Time.Ticks);
        }

        /// <summary>
        /// Randomly returns true or false.
        /// </summary>
        public static bool Bool()
        {
            return random.Next(2) == 0 ? true : false;
        }

        /// <summary>
        /// Returns a random floating-point value between 0 and 1.
        /// </summary>
        /// <returns></returns>
        public static float Float()
        {
            return (float)random.NextDouble();
        }

        /// <summary>
        /// Randomly returns 1 or -1;
        /// </summary>
        public static sbyte Sign()
        {
            return random.Next(2) == 0 ? (sbyte)1 : (sbyte)-1;
        }

        /// <summary>
        /// Returns a random angle in radians.
        /// </summary>
        public static float Angle()
        {
            return Float() * MathHelper.TwoPi;
        }

        /// <summary>
        /// Returns a <see cref="Microsoft.Xna.Framework.Vector2"/> with it's X and Y components a random floating-point number between 0 and 1.
        /// </summary>
        /// <returns></returns>
        public static Vector2 Vector2()
        {
            return new Vector2(Float(), Float());
        }

        /// <summary>
        /// Returns a <see cref="Microsoft.Xna.Framework.Vector2"/> with it's X and Y components a random floating-point number between -1 and 1.
        /// </summary>
        /// <returns></returns>
        public static Vector2 SVector2()
        {
            return Vector2() * new Vector2(Sign(), Sign());
        }

        /// <summary>
        /// Returns a random <see cref="Microsoft.Xna.Framework.Color"/>.
        /// </summary>
        public static Color Color()
        {
            return new Color(
                random.Next(256),
                random.Next(256),
                random.Next(256));
        }

        /// <summary>
        /// Returns a random <see cref="Color"/> from <paramref name="palette"/>.
        /// </summary>
        /// <param name="palette">The <see cref="Palette"/> to return a <see cref="Color"/> from.</param>
        /// <returns></returns>
        public static Color Color(Palette palette)
        {
            return palette.colors[FromRange(0, palette.Size)];
        }

        /// <summary>
        /// Returns a random integer between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="min">The minimum value that will be returned.</param>
        /// <param name="max">The maximum value that will be returned.</param>
        /// <returns></returns>
        public static int FromRange(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// Returns a random floating-point number between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="min">The minimum value that will be returned.</param>
        /// <param name="max">The maximum value that will be returned.</param>
        public static float FromRange(float min, float max)
        {
            return FromRange((int)min, (int)max) * (float)random.NextDouble();
        }
    }
}
