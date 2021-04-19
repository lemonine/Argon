using System.Collections.Generic;
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

        public List<Component> components;

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
        /// <summary>
        /// Override this to update this <see cref="Entity"/>'s <see cref="CCollider"/>. Has no base logic.
        /// </summary>
        protected virtual void UpdateCollider()
        {

        }
        /// <summary>
        /// This is called when a collision occurs with another <see cref="Entity"/>.
        /// Override this to add custom events on collision. Has no base logic.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> that collided with this <see cref="Entity"/>.</param>
        /// <param name="collider">The collider that this <see cref="Entity"/> collided with.</param>
        /// <param name="caller">The <see cref="CCollider"/> that called this method.</param>
        public virtual void OnCollisionBegin(Entity entity, CCollider collider, CCollider caller)
        {

        }
        /// <summary>
        /// This is called when a collision has been occuring for at least on frame with another
        /// <see cref="Entity"/>. Override this to add custom events on collision. Has no base logic.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> that collided with this <see cref="Entity"/>.</param>
        /// /// <param name="collider">The collider that this <see cref="Entity"/> collided with.</param>
        /// <param name="caller">The <see cref="CCollider"/> that called this method.</param>
        public virtual void OnCollisionRemain(Entity entity, CCollider collider, CCollider caller)
        {

        }
        /// <summary>
        /// This is called when a collision has ended with another <see cref="Entity"/>.
        /// Override this to add custom events on collision. Has no base logic.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> that collided with this <see cref="Entity"/>.</param>
        /// /// <param name="collider">The collider that this <see cref="Entity"/> collided with.</param>
        /// <param name="caller">The <see cref="CCollider"/> that called this method.</param>
        public virtual void OnCollisionEnd(Entity entity, CCollider collider, CCollider caller)
        {

        }
    }
}
