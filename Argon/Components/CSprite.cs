using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Argon.Graphics;

namespace Argon.Components
{
    /// <summary>
    /// A <see cref="Component"/> that can be moved, rotated, scaled, and drawn.
    /// </summary>
    public class CSprite : Component
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle slice;
        public Color color;
        public float rotation;
        public Vector2 origin;
        public Vector2 scale;
        public SpriteEffects effects;
        public float layer;

        public Texture2D mask;
        public SpriteOutline outline;

        public CSprite(
            Entity parent,
            Texture2D texture,
            Vector2 position,
            Rectangle slice,
            Color color,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            SpriteEffects effects,
            float layer,
            bool active = true) : base(parent, active)
        {
            this.texture = texture;
            this.position = position;
            this.slice = slice;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layer = layer;
        }

        /// <summary>
        /// Draws this <see cref="CSprite"/>.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                slice,
                color,
                rotation,
                origin,
                scale,
                effects,
                layer);
        }

        /// <summary>
        /// Draws a one-pixel wide outline around this <see cref="CSprite"/>.
        /// TODO - Work with other <see cref="SpriteSortMode"/>s and do on GPU.
        /// </summary>
        ///<param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        /// <param name="sortMode"
        public void DrawOutline(SpriteBatch spriteBatch)
        {
            if (mask == null)
            {
                mask = texture.CreateMask();
            }

            foreach (Vector2 offset in outline.MaskOffsets)
            {
                spriteBatch.Draw(
                mask,
                position + offset,
                slice,
                outline.color,
                rotation,
                origin,
                scale,
                effects,
                layer - 0.01f);
            }
        }
    }
}
