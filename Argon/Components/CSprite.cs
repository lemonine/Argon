using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
    }
}
