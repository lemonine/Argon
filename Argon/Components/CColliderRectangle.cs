using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Argon.Graphics;

namespace Argon.Components
{
    /// <summary>
    /// A rectangular <see cref="Component"/> that can detect <see cref="Entity"/> collisions.
    /// </summary>
    public class CColliderRectangle : CCollider
    {
        public int width;
        public int height;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(X, Y, width, height);
            }
        }

        public CColliderRectangle(
            Entity parent,
            int X,
            int Y,
            int width,
            int height,
            bool active = true) : base(parent, active)
        {
            this.X = X;
            this.Y = Y;
            this.width = width;
            this.height = height;
        }

        public override void CheckCollisions(Entity entity)
        {
            base.CheckCollisions(entity);

            List<CCollider> colliders = new List<CCollider>();

            foreach (Component component in entity.components)
            {
                if (component is CCollider collider)
                {
                    colliders.Add(collider);
                }
            }

            foreach (CCollider collider in colliders)
            {
                if (collider is CColliderCircle colliderCircle)
                {
                    if (Bounds.Overlaps(colliderCircle.Circle))
                    {
                        isColliding = true;
                        CallParentMethods(entity, colliderCircle);
                    }
                }

                if (collider is CColliderRectangle colliderRectangle)
                {
                    if (Bounds.Intersects(colliderRectangle.Bounds))
                    {
                        isColliding = true;
                        CallParentMethods(entity, colliderRectangle);
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (draw)
            {
                spriteBatch.DrawRectangle(Bounds, drawColor, layer: drawLayer);
            }
        }
    }
}
