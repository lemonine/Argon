using Microsoft.Xna.Framework;
using Argon.Components;

namespace Argon
{
    /// <summary>
    /// The base class for <see cref="Argon"/> game objects. Entities can be updated, drawn,
    /// and have components attatched to them.
    /// </summary>
    public abstract class Entity
    {
        public Vector2 position;
        public float rotation;
        public Vector2 origin;
        public Vector2 scale;
        public bool active;
        public bool visible = true;

        public Entity()
        {

        }

        public Entity(bool _active = true, bool _visible = true)
        {
            active = _active;
            visible = _visible;
        }

        public Entity(
            Vector2 _position,
            float _rotation,
            Vector2 _origin,
            Vector2 _scale,
            bool _active = true,
            bool _visible = true)
        {
            position = _position;
            rotation = _rotation;
            origin = _origin;
            scale = _scale;
            active = _active;
            visible = _visible;
        }

        /// <summary>
        /// Instantiates the <see cref="Component"/>(s) attached to this <see cref="Entity"/>.
        /// Call this in the constructor.
        /// </summary>
        public abstract void InstantiateComponents();

        /// <summary>
        /// Updates this <see cref="Entity"/>.
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Draws this <see cref="Entity"/>.
        /// </summary>
        public abstract void Draw();
    }
}
