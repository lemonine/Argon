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
        public bool correctExceedingVelocity = true;
        public bool correctExceedingAngularVelocity = true;
        public Vector2 fallbackVelocity;
        public float fallbackAngularVelocity;

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
            float angularVelocity,
            float mass = 1,
            bool active = true) : base(parent, active)
        {
            this.velocity = velocity;
            this.angularVelocity = angularVelocity;
            this.mass = mass;
        }

        public CBody(
            Entity parent,
            Vector2 velocity,
            Vector2 terminalVelocity,
            float angularVelocity,
            float terminalAngularVelocity,
            float mass = 1,
            bool active = true) : base(parent, active)
        {
            this.velocity = velocity;
            this.terminalVelocity = terminalVelocity;
            this.angularVelocity = angularVelocity;
            this.terminalAngularVelocity = terminalAngularVelocity;
            this.mass = mass;
        }

        public CBody(
            Entity parent,
            Vector2 velocity,
            Vector2 terminalVelocity,
            Vector2 fallbackVelocity,
            float angularVelocity,
            float terminalAngularVelocity,
            float fallbackAngularVelocity,
            float mass = 1,
            bool active = true) : base(parent, active)
        {
            this.velocity = velocity;
            this.terminalVelocity = terminalVelocity;
            this.fallbackVelocity = fallbackVelocity;
            this.angularVelocity = angularVelocity;
            this.terminalAngularVelocity = terminalAngularVelocity;
            this.fallbackAngularVelocity = fallbackAngularVelocity;
            this.mass = mass;
        }

        /// <summary>
        /// Updates this <see cref="CBody"/> and sets its fields to its parents' if specified.
        /// </summary>
        public override void Update()
        {
            if (useRawVelocity)
            {
                Debug.LogIf(
                    velocity.X > terminalVelocity.X || velocity.Y > terminalVelocity.Y,
                    "Velocity exceeds terminal velocity." + (correctExceedingVelocity ? " Correcting." : ""),
                    this);

                if (correctExceedingVelocity)
                {
                    velocity = fallbackVelocity;
                }
            }
            if (useRawAngularVelocity)
            {
                Debug.LogIf(
                    angularVelocity > terminalAngularVelocity || velocity.Y > terminalVelocity.Y,
                    "Angular velocity exceeds angular terminal velocity." + (correctExceedingVelocity ? " Correcting." : ""),
                    this);

                if (correctExceedingVelocity)
                {
                    angularVelocity = fallbackAngularVelocity;
                }
            }

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
