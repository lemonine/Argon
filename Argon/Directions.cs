﻿using Microsoft.Xna.Framework;

namespace Argon
{
    /// <summary>
    /// Provides properties for cardinal and diagonal directions.
    /// </summary>
    public static class Directions
    {
        public static Vector2 Left
        {
            get { return new Vector2(-1, 0); }
        }
        public static Vector2 Up
        {
            get { return new Vector2(0, -1); }
        }
        public static Vector2 Right
        {
            get { return new Vector2(1, 0); }
        }
        public static Vector2 Down
        {
            get { return new Vector2(0, 1); }
        }
        public static Vector2 UpLeft
        {
            get { return new Vector2(-1, -1); }
        }
        public static Vector2 UpRight
        {
            get { return new Vector2(1, -1); }
        }
        public static Vector2 DownLeft
        {
            get { return new Vector2(1, -1); }
        }
        public static Vector2 DownRight
        {
            get { return new Vector2(1, 1); }
        }
    }
}
