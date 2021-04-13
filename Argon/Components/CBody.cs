using Microsoft.Xna.Framework;

namespace Argon.Components
{
    /// <summary>
    /// A <see cref="Component"/> that represents an <see cref="Entity"/>'s physics.
    /// </summary>
    public class CBody : Component
    {
        public Vector2 velocity;
        public float angularVelocity;
        public Vector2 terminalVelocity;
        public float terminalAngularVelocity;
        public float mass;

        /// <summary>
        /// <see cref="velocity"/> multiplied by <see cref="mass"/>.
        /// </summary>
        public Vector2 VecocityCalculated
        {
            get
            {
                return new Vector2(
                    MathHelper.Min(velocity.X, terminalVelocity.X),
                    MathHelper.Min(velocity.Y, terminalVelocity.Y));
            }
        }
        /// <summary>
        /// <see cref="angularVelocity"/> multiplied by <see cref="mass"/>.
        /// </summary>
        public float AngularVelocityCalculated
        {
            get
            {
                return MathHelper.Min(angularVelocity * mass, terminalAngularVelocity);
            }
        }

        public CBody(
            Entity parent,
            Vector2 velocity,
            float angularVelocity = 0,
            float mass = 1,
            bool active = true) : base(parent, active)
        {
            this.velocity = velocity;
            this.angularVelocity = angularVelocity;
            this.mass = mass;
        }
    }
}
