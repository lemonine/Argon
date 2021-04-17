using Microsoft.Xna.Framework;
using Argon.Components;

namespace Argon
{
    /// <summary>
    /// The base class for physics-based <see cref="Argon"/> game objects. Entities can be updated, drawn, and have components
    /// attatched to them. <see cref="PhysicsEntity"/> and <see cref="SpriteEntity"/> have a <see cref="CSprite"/> attached to them.
    /// </summary>
    public class PhysicsEntity : SpriteEntity
    {
        protected CBody physics;

        public PhysicsEntity()
        {

        }

        public PhysicsEntity(bool active = true, bool visible = true) : base(active, visible)
        {

        }

        public PhysicsEntity(
            Vector2 position,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            bool active = true,
            bool visible = true) : base(active, visible)
        {

        }

        /// <summary>
        /// Updates this <see cref="physics"/>'s <see cref="CSprite"/> and <see cref="CBody"/>. Override this to add additional update code.
        /// </summary>
        public override void Update()
        {
            UpdateBody();

            base.Update();
        }

        /// <summary>
        /// Updates this <see cref="PhysicsEntity"/>'s <see cref="CBody"/>. Override this to update this <see cref="Entity"/>'s <see cref="CBody"/>.
        /// </summary>
        protected override void UpdateBody()
        {
            if (physics.active)
            {
                physics.Update();
            }
        }
    }
}
