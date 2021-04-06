namespace Argon
{
    /// <summary>
    /// A static version of <see cref="System.Random"/>.
    /// </summary>
    public static class Random
    {
        private static System.Random random;

        static Random()
        {
            random = new System.Random(27466);
        }

        /// <summary>
        /// Sets the seed for the <see cref="System.Random"/> instance.
        /// </summary>
        /// <param name="seed"></param>
        public static void SetSeed(int seed)
        {
            random = new System.Random(seed);
        }

        /// <summary>
        /// Returns a positive integer.
        /// </summary>
        /// <returns></returns>
        public static int Integer()
        {
            return random.Next();
        }

        /// <summary>
        /// Returns a positive integer less than <paramref name="maxValue"/>.
        /// </summary>
        /// <param name="maxValue">One more than the maximum value that will be returned.</param>
        public static int Integer(int maxValue)
        {
            return random.Next(maxValue);
        }

        /// <summary>
        /// Returns an integer that is within the specified range.
        /// </summary>
        /// <param name="minValue">The minimum value that will be returned.</param>
        /// <param name="maxValue">One more than the maximum value that will be returned.</param>
        /// <returns></returns>
        public static int Integer(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a single-precision floating-point number between 0.0 and 1.0.
        /// </summary>
        /// <returns></returns>
        public static float Float()
        {
            return (float)random.NextDouble();
        }
    }
}
