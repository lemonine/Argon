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

        public bool updateParentPosition = true;
        public bool updateParentRotation = true;
        public bool useRawVelocity = false;
        public bool useRawAngularVelocity = false;

        /// <summary>
        /// <see cref="velocity"/> multiplied by <see cref="mass"/>, capped at <see cref="terminalVelocity"/>.
        /// </summary>
        public Vector2 VelocityCalculated
        {
            get
            {
                return new Vector2(
                    MathHelper.Min(velocity.X, terminalVelocity.X),
                    MathHelper.Min(velocity.Y, terminalVelocity.Y));
            }
        }
        /// <summary>
        /// <see cref="angularVelocity"/> multiplied by <see cref="mass"/>, capped at <see cref="terminalAngularVelocity"/>.
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

        /// <summary>
        /// Updates this <see cref="CBody"/> and sets its fields to its parents' if specified.
        /// </summary>
        public override void Update()
        {
            if (HasParent)
            {
                if (updateParentPosition)
                {
                    parent.position += useRawVelocity ? velocity : VelocityCalculated;
                }
                if (updateParentRotation)
                {
                    parent.rotation += useRawAngularVelocity ? angularVelocity : AngularVelocityCalculated;
                }
            }

            base.Update();
        }
    }
}
