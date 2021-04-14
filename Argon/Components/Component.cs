using Microsoft.Xna.Framework;

namespace Argon.Components
{
    /// <summary>
    /// The base class for <see cref="Argon"/> components. A <see cref="Component"/>
    /// can be attached to an <see cref="Entity"/>.
    /// </summary>
    public abstract class Component
    {
        protected readonly Entity parent;
        public bool active;

        /// <summary>
        /// Whether or not this <see cref="Component"/> is attached to an <see cref="Entity"/>.
        /// </summary>
        protected bool HasParent
        {
            get
            {
                return parent != null;
            }
        }

        public Component()
        {

        }

        public Component(Entity parent, bool active = true)
        {
            this.parent = parent;
            this.active = active;
        }

        /// <summary>
        /// Updates this <see cref="Component"/>.
        /// </summary>
        public virtual void Update()
        {
            if (HasParent && !parent.active)
            {
                active = false;
            }

            Debug.LogIf(!active, "Inactive Component was updated.", this);
            Debug.LogIf(!HasParent, "Parentless Component in use.", this);
        }
    }
}
