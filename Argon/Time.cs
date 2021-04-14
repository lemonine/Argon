using System;
using Microsoft.Xna.Framework;

namespace Argon
{
    /// <summary>
    /// Provides read-only data about time.
    /// </summary>
    public static class Time
    {
        private static GameTime gameTime;

        /// <summary>
        /// The amount of ticks the game has been running for. (Approximately 60 per second.)
        /// </summary>
        public static int Ticks
        {
            get
            {
                return (int)gameTime.TotalGameTime.Ticks;
            }
        }
        /// <summary>
        /// The amount of whole seconds the game has been running for. (Rounded down.)
        /// </summary>
        public static int WholeSeconds
        {
            get
            {
                return (int)Math.Floor(Seconds);
            }
        }
        /// <summary>
        /// The amount of seconds the game has been running for.
        /// </summary>
        public static float Seconds
        {
            get
            {
                return (float)gameTime.TotalGameTime.TotalSeconds;
            }
        }
        /// <summary>
        /// The amount of time since the last frame.
        /// </summary>
        public static float DeltaTime
        {
            get
            {
                return (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }


        /// <summary>
        /// Updates <see cref="Time"/>.
        /// </summary>
        /// <param name="gameTime">The time since <see cref="Time.Update(GameTime)"/> was last called.</param>
        public static void Update(GameTime gameTime)
        {
            Time.gameTime = gameTime;
        }
    }
}
