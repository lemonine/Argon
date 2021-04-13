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
        public Atlas atlas;
        public Vector2 position;
        public int sliceIndex;
        public Color color;
        public float rotation;
        public Vector2 origin;
        public Vector2 scale;
        public SpriteEffects effects;
        public float layer;

        public Texture2D mask;
        public SpriteOutline outline;

        public bool useParentPosition = true;
        public bool useParentRotation = true;
        public bool useParentOrigin = true;
        public bool useParentScale = true;

        /// <summary>
        /// The <see cref="Texture2D"/> that will be drawn.
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return atlas.texture;
            }
        }
        /// <summary>
        /// The region of <see cref="Texture"/> that will be drawn.
        /// </summary>
        public Rectangle Slice
        {
            get
            {
                return atlas.slices[sliceIndex];
            }
        }

        public CSprite(
            Entity parent,
            Atlas atlas,
            Vector2 position,
            int sliceIndex,
            Color color,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            SpriteEffects effects,
            float layer,
            bool active = true) : base(parent, active)
        {
            this.atlas = atlas;
            this.position = position;
            this.sliceIndex = sliceIndex;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layer = layer;

            outline = SpriteOutline.Invisible;
        }

        /// <summary>
        /// Updates this <see cref="CSprite"/> and sets its fields to its parents' if specified.
        /// </summary>
        public override void Update()
        {
            if (HasParent)
            {
                if (useParentPosition)
                {
                    position = parent.position;
                }
                if (useParentRotation)
                {
                    rotation = parent.rotation;
                }
                if (useParentOrigin)
                {
                    origin = parent.origin;
                }
                if (useParentScale)
                {
                    scale = parent.scale;
                }
            }

            base.Update();
        }

        /// <summary>
        /// Draws this <see cref="CSprite"/>.
        /// </summary>
        /// <param name="spriteBatch">The actively-batching <see cref="SpriteBatch"/> instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(
                    (int)this.position.X,
                    (int)this.position.Y);

            spriteBatch.Draw(
                Texture,
                position,
                Slice,
                color,
                rotation,
                origin,
                scale,
                effects,
                layer);

            Debug.LogIf(!active, "Inactive CSprite was drawn.", this);
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
                mask = Texture.CreateMask();
                Debug.Log("Mask was null, a new mask was created", this);
            }

            foreach (Vector2 offset in outline.MaskOffsets)
            {
                Vector2 position = new Vector2(
                    (int)this.position.X + offset.X,
                    (int)this.position.Y + offset.Y);

                spriteBatch.Draw(
                mask,
                position,
                Slice,
                outline.color,
                rotation,
                origin,
                scale,
                effects,
                layer - 0.01f);
            }

            if (!outline.active)
            {
                Debug.LogIf(!outline.active, "Inactive or invisible SpriteOutline was drawn", this);
            }
        }
    }
}
