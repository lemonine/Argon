using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Argon.Graphics;

namespace Argon.Components
{
    /// <summary>
    /// A radial <see cref="Component"/> that can detect <see cref="Entity"/> collisions
    /// </summary>
    public class CColliderCircle : CCollider
    {
        public float radius;

        /// <summary>
        /// A <see cref="Circle"/> that represents this <see cref="CColliderCircle"/>.
        /// </summary>
        public Circle Circle
        {
            get
            {
                return new Circle(X, Y, radius);
            }
        }
        /// <summary>
        /// The center of this <see cref="CColliderCircle"/>.
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return Circle.Center;
            }
        }

        public CColliderCircle(
            Entity parent,
            int X,
            int Y,
            float radius,
            bool active = true) : base(parent, active)
        {
            this.X = X;
            this.Y = Y;
            this.radius = radius;
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
                    if (Circle.Overlaps(colliderCircle.Circle))
                    {
                        isColliding = true;
                        CallParentMethods(entity, colliderCircle);
                    }
                }

                if (collider is CColliderRectangle colliderRectangle)
                {
                    if (Circle.Overlaps(colliderRectangle.Bounds))
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
                spriteBatch.DrawCircle(Center, radius, drawColor, layer: drawLayer);
            }
        }
    }
}
