using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon.Components
{
    /// <summary>
    /// A <see cref="Component"/> that can detect <see cref="Entity"/> collisions and
    /// acts as a base for implemented <see cref="CCollider"/>s.
    /// </summary>
    public abstract class CCollider : Component
    {
        public int X;
        public int Y;
        public bool isColliding;
        public bool wasColliding;
        public bool draw;
        public float drawLayer;
        public Color drawColor;

        public bool useParentPosition = true;

        public CCollider(Entity parent, bool active = true) : base(parent, active)
        {

        }

        /// <summary>
        /// Updates this <see cref="CCollider"/>. Call this BEFORE updating the child and call
        /// Update() (parameterless overload) after updating the child.
        /// </summary>
        /// <param name="collider">The <see cref="CCollider"/> to check.</param>
        public virtual void CheckCollisions(CCollider collider)
        {
            wasColliding = isColliding;
        }

        /// <summary>
        /// Draws this <see cref="CCollider"/> if <see cref="draw"/> is true.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
