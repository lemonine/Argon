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

        public override void CheckCollisions(CCollider collider)
        {
            base.Update();

            Update();
        }

        public override void Update()
        {
            base.Update();

            if (useParentPosition)
            {
                X = (int)parent.position.X;
                Y = (int)parent.position.Y;
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
