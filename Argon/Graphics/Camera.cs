using Microsoft.Xna.Framework;

namespace Argon.Graphics
{
    /// <summary>
    /// Creates a <see cref="Matrix"/> that can be used to offset a sprite batch.
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
                    Matrix.CreateTranslation(new Vector3(-origin, 0)) *
                    Matrix.CreateRotationZ(rotation) *
                    Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                    Matrix.CreateTranslation(new Vector3(origin, 0));
            }
        }
        /// <summary>
        /// Represents the bounds of this <see cref="Camera"/>'s orthographic view in the world.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return ScreenToWorld(new Rectangle(0, 0, width, height));
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
        public Vector2 WorldToScreen(Vector2 vector)
        {
            return Vector2.Transform(vector, View);
        }

        /// <summary>
        /// Returns <paramref name="vector"/>'s position in the game.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2"/>'s position on the screen.</param>
        public Vector2 ScreenToWorld(Vector2 vector)
        {
            return Vector2.Transform(vector, Matrix.Invert(View));
        }

        /// <summary>
        /// Returns <paramref name="point"/>'s position on the screen.
        /// </summary>
        /// <param name="point">The <see cref="Point"/>'s position in the game.</param>
        public Point WorldToScreen(Point point)
        {
            return WorldToScreen(point.ToVector2()).ToPoint();
        }

        /// <summary>
        /// Returns <paramref name="point"/>'s position in the game.
        /// </summary>
        /// <param name="point">The <see cref="Point"/>'s position on the screen.</param>
        /// <returns></returns>
        public Point ScreenToWorld(Point point)
        {
            return ScreenToWorld(point.ToVector2()).ToPoint();
        }

        /// <summary>
        /// Returns <paramref name="rectangle"/>'s bounds on the screen.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle"/>'s bounds in the game.</param>
        public Rectangle WorldToScreen(Rectangle rectangle)
        {
            return new Rectangle(WorldToScreen(rectangle.Location),
                new Point((int)(rectangle.Width * zoom), (int)(rectangle.Height * zoom)));
        }

        /// <summary>
        /// Returns <paramref name="rectangle"/>'s bounds in the game.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle"/>'s bounds on the screen.</param>
        public Rectangle ScreenToWorld(Rectangle rectangle)
        {
            return 
                new Rectangle(ScreenToWorld(rectangle.Location),
                new Point((int)(rectangle.Width / zoom), (int)(rectangle.Height / zoom)));
        }
    }
}
