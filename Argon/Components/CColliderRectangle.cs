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
                spriteBatch.DrawRectangle(Bounds, drawColor, layer: drawLayer);
            }
        }
    }
}
