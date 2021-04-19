namespace Argon
{
    /// <summary>
    /// Allows logging to the VS Output Window.
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// Determines whether or not <see cref="Argon"/> classes should log debug data.
        /// </summary>
        public static bool autoLog;

        /// <summary>
        /// Logs <paramref name="value"/>.ToString() to the VS Output Window.
        /// </summary>
        /// <param name="value">The message to log.</param>
        /// <param name="logger">The <see cref="object"/> logging <paramref name="value"/>.</param>
        public static void Log(object value, object logger = null)
        {
            if (autoLog)
            {
                if (logger == null)
                {
                    System.Diagnostics.Debug.WriteLine(value);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(logger == null ? "Logger unknown" : logger + ": " + value);
                }
            }
        }

        /// <summary>
        /// Logs <paramref name="value"/>.ToString() to the VS Output Window if <paramref name="condition"/> is true.
        /// </summary>
        /// <param name="value">The message to log.</param>
        /// <param name="logger">The <see cref="System.Object"/> logging <paramref name="value"/>.</param>
        /// <param name="condition">The condition.</param>
        public static void LogIf(bool condition, object value, object logger = null)
        {
            if (condition)
            {
                Log(value, logger);
            }
        }
    }
}
