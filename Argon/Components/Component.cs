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

        public Component()
        {

        }

        public Component(Entity _parent, bool _active = true)
        {
            parent = _parent;
            active = _active;
        }

        /// <summary>
        /// Updates this <see cref="Component"/>.
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
