using Microsoft.Xna.Framework;

namespace Argon
{
    /// <summary>
    /// Uses a <see cref="Matrix"/> to offset a sprite batch.
    /// </summary>
    public class Camera
    {
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public float zoom;
        public readonly int width;
        public readonly int height;

        /// <summary>
        /// Represents this <see cref="Camera"/>'s orthographic view.
        /// </summary>
        public Matrix View
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(-position, 0)) *
                    Matrix.CreateRotationZ(rotation) *
                    Matrix.CreateScale(zoom) *
                    Matrix.CreateTranslation(new Vector3(position - origin, 0));
            }
        }

        public Camera(
            Vector2 _position,
            Vector2 _origin,
            float _rotation,
            float _zoom,
            int _width,
            int _height)
        {
            position = _position;
            origin = _origin;
            rotation = _rotation;
            zoom = _zoom;
            width = _width;
            height = _height;
        }

        /// <summary>
        /// Returns <paramref name="vector"/>'s position on the screen.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2"/>'s position in the game.</param>
        /// <returns></returns>
        public Vector2 WorldToScreen(Vector2 vector)
        {
            return Vector2.Transform(vector, View);
        }

        /// <summary>
        /// Returns <paramref name="vector"/>'s position in the game.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2"/>'s position on the screen.</param>
        /// <returns></returns>
        public Vector2 ScreenToWorld(Vector2 vector)
        {
            return Vector2.Transform(vector, Matrix.Invert(View));
        }
    }
}
