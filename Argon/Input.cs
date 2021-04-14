using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Argon.Graphics;

namespace Argon
{
    /// <summary>
    /// Provides various shortcuts to <see cref="Microsoft.Xna.Framework"/> input code.
    /// </summary>
    public static class Input
    {
        private static KeyboardState keyboard;
        private static KeyboardState lastKeyboard;
        private static MouseState mouse;
        private static MouseState lastMouse;

        /// <summary>
        /// Returns a <see cref="Vector2"/> (unit vector) representing the direction of the WASD or arrow <see cref="Keys"/>.
        /// </summary>
        public static Vector2 Direction
        {
            get
            {
                Vector2 direction = Vector2.Zero;

                if (IsKeyPressed(Keys.A) || IsKeyPressed(Keys.Left))
                {
                    direction.X -= 1;
                }
                else if (IsKeyPressed(Keys.D) || IsKeyPressed(Keys.Right))
                {
                    direction.X++;
                }

                if (IsKeyPressed(Keys.W) || IsKeyPressed(Keys.Up))
                {
                    direction.Y -= 1;
                }
                else if (IsKeyPressed(Keys.S) || IsKeyPressed(Keys.Down))
                {
                    direction.Y++;
                }

                return direction;
            }
        }
        /// <summary>
        /// Returns the positon of the mouse in screen coordinates.
        /// </summary>
        public static Vector2 MousePosition
        {
            get
            {
                return mouse.Position.ToVector2();
            }
        }

        /// <summary>
        /// Updates the user's input into this class's fields.
        /// </summary>
        public static void Update()
        {
            lastKeyboard = keyboard;
            keyboard = Keyboard.GetState();
            lastMouse = mouse;
            mouse = Mouse.GetState();
        }

        /// <summary>
        /// Returns whether or not <paramref name="key"/> is being pressed this frame.
        /// </summary>
        /// <param name="key">The <see cref="Keys"/> to check input for.</param>
        /// <returns></returns>
        public static bool IsKeyPressed(Keys key)
        {
            return keyboard.IsKeyDown(key);
        }
    }
}
