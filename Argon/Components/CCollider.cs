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
        /// <param name="entity">The <see cref="Entity"/> to check.</param>
        public virtual void CheckCollisions(Entity entity)
        {
            wasColliding = isColliding;
        }
        
        /// <summary>
        /// Calls methods in the parent to let them know what type of collisions are occuring.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> that collider with this
        /// <see cref="CCollider"/>'s parent.</param>
        public void CallParentMethods(Entity entity, CCollider collider)
        {
            if (isColliding && !wasColliding)
            {
                parent.OnCollisionBegin(entity, collider, this);
            }
            else if (isColliding && wasColliding)
            {
                parent.OnCollisionRemain(entity, collider, this);
            }
            else if (!isColliding && wasColliding)
            {
                parent.OnCollisionEnd(entity, collider, this);
            }
        }

        public override void Update()
        {
            if (useParentPosition)
            {
                X = (int)parent.position.X;
                Y = (int)parent.position.Y;
            }

            base.Update();
        }

        /// <summary>
        /// Draws this <see cref="CCollider"/> if <see cref="draw"/> is true.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
