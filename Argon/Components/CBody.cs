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
            Entity _parent,
            Vector2 _velocity,
            float _angularVelocity = 0,
            float _mass = 0,
            bool _active = true) : base(_parent, _active)
        {
            velocity = _velocity;
            angularVelocity = _angularVelocity;
            mass = _mass;
        }
    }
}
