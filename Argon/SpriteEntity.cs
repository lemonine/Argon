using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Argon.Components;
using Argon.Graphics;

namespace Argon
{
    /// <summary>
    /// The base class for <see cref="Argon"/> game objects. Entities can be updated, drawn,
    /// and have components attatched to them. <see cref="SpriteEntity"/> have a <see cref="CSprite"/> attached to them.
    /// </summary>
    public class SpriteEntity : Entity
    {
        protected CSprite sprite;

        public SpriteEntity()
        {

        }

        public SpriteEntity(bool active = true, bool visible = true) : base(active, visible)
        {

        }

        public SpriteEntity(
            Vector2 position,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            bool active = true,
            bool visible = true) : base(active, visible)
        {

        }

        /// <summary>
        /// Updates this <see cref="SpriteEntity"/>'s <see cref="CSprite"/>. Override this to add additional update code.
        /// </summary>
        public override void Update()
        {
            UpdateSprite();

            base.Update();
        }

        /// <summary>
        /// Updates this <see cref="SpriteEntity"/>'s <see cref="CSprite"/>. /// Override this to update this <see cref="Entity"/>'s <see cref="CSprite"/>.
        /// </summary>
        protected override void UpdateSprite()
        {
            if (sprite.active)
            {
                sprite.Update();
            }
        }

        /// <summary>
        /// Draws this <see cref="SpriteEntity"/> and it's <see cref="CSprite"/>s <see cref="SpriteOutline"/>.
        /// Override this to add additional drawing code.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (sprite.active)
            {
                sprite.Draw(spriteBatch);

                if (sprite.outline.active)
                {
                    sprite.DrawOutline(spriteBatch);
                }
            }

            base.Draw(spriteBatch);
        }
    }
}
