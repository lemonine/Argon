using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public bool visible;

        public Entity()
        {

        }

        public Entity(bool active = true, bool visible = true)
        {
            this.active = active;
            this.visible = visible;
        }

        public Entity(
            Vector2 position,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            bool active = true,
            bool visible = true)
        {
            this.position = position;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.active = active;
            this.visible = visible;
        }

        /// <summary>
        /// Override this to instantiate the <see cref="Component"/>(s) attached to this <see cref="Entity"/>.
        /// Call this in the constructor.
        /// </summary>
        public virtual void InstantiateComponents()
        {

        }

        /// <summary>
        /// Override this to update this <see cref="Entity"/>.
        /// </summary>
        public virtual void Update()
        {
            Debug.LogIf(!active, "Inactive Entity was updated!", this);
        }
        /// <summary>
        /// Override this to draw this <see cref="Entity"/>.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Debug.LogIf(!active || !visible, "Inactive or invisible Entity was drawn!", this);
        }
        /// <summary>
        /// Override this to update this <see cref="Entity"/>'s <see cref="CSprite"/>.
        /// </summary>
        protected virtual void UpdateSprite()
        {

        }
        /// <summary>
        /// Override this to update this <see cref="Entity"/>'s <see cref="CBody"/>.
        /// </summary>
        protected virtual void UpdateBody()
        {
            
        }
    }
}
