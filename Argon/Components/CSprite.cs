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
        public Texture2D mask;
        public Vector2 position;
        public Rectangle slice;
        public Color color;
        public float rotation;
        public Vector2 origin;
        public Vector2 scale;
        public SpriteEffects effects;
        public float layer;

        public CSprite(
            Entity _parent,
            Texture2D _texture,
            Vector2 _position,
            Rectangle _slice,
            Color _color,
            float _rotation,
            Vector2 _origin,
            Vector2 _scale,
            SpriteEffects _effects,
            float _layer,
            bool _active = true) : base(_parent, _active)
        {
            texture = _texture;
            position = _position;
            slice = _slice;
            color = _color;
            rotation = _rotation;
            origin = _origin;
            scale = _scale;
            effects = _effects;
            layer = _layer;
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
        /// <param name="color">The <see cref="Color"/> of the outline.</param>
        /// <param name="type">The <see cref="SpriteOutlineType"/> of the outline.</param>
        /// <param name="sortMode"
        public void DrawOutline(SpriteBatch spriteBatch, Color color, SpriteOutlineType type)
        {
            Vector2[] offsets = new Vector2[]
            {
                new Vector2(-1, 0),
                new Vector2(0, -1),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(-1, -1),
                new Vector2(1, -1),
                new Vector2(-1, 1),
                new Vector2(1, 1)
            };

            if (mask == null)
            {
                mask = texture.GetMask(spriteBatch.GraphicsDevice);
            }

            for (int i = 0; i < offsets.Length / (type == SpriteOutlineType.Circle ? 2 : 1); i++)
            {
                spriteBatch.Draw(
                mask,
                position + offsets[i],
                slice,
                color,
                rotation,
                origin,
                scale,
                effects,
                layer + 0.01f);
            }    
        }
    }
}
