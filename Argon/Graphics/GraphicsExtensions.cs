﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon.Graphics
{
    /// <summary>
    /// Provides various extensions to <see cref="Microsoft.Xna.Framework"/> (XNA) classes.
    /// </summary>
    public static class GraphicsExtensions
    {
        /// <summary>
        /// Begins a new sprite batch with <paramref name="parameters"/>.
        /// </summary>
        /// <param name="spriteBatch">This <see cref="SpriteBatch"/> instance.</param>
        /// <param name="parameters">The sprite batch parameters</param>
        public static void Begin(this SpriteBatch spriteBatch, SpriteBatchParameters parameters)
        {
            spriteBatch.Begin(
                parameters.sortMode,
                parameters.blendState,
                parameters.samplerState,
                parameters.depthStencilState,
                parameters.rasterizerState,
                parameters.effect,
                parameters.transformMatrix);
        }

        /// <summary>
        /// Draws a line from <paramref name="pointA"/> to <paramref name="pointB"/>, with a tint of <paramref name="color"/>,
        /// a width of <paramref name="width"/>, and a depth of <paramref name="layer"/>.
        /// </summary>
        /// <param name="spriteBatch">This <see cref="SpriteBatch"/> instance.</param>
        /// <param name="pointA">The start of this line</param>
        /// <param name="pointB">The end of this line.</param>
        /// <param name="color">The <see cref="Color"/> of this line.</param>
        /// <param name="width">The width of this line.</param>
        /// <param name="layer">The depth of this line.</param>
        public static void DrawLine(
            this SpriteBatch spriteBatch,
            Vector2 pointA,
            Vector2 pointB,
            Color color,
            float width = 1,
            float layer = 0)
        {
            Vector2 position = new Vector2(pointA.X, pointA.Y - width);
            float rotation = (pointB - pointA).ToAngle();
            Vector2 origin = Vector2.UnitX / width * width;
            Vector2 scale = new Vector2(width, (pointB - pointA).Length());

            spriteBatch.Draw(
                Assets.pixelTexture,
                position,
                default,
                color,
                rotation,
                origin,
                scale,
                SpriteEffects.None,
                layer);
        }

        /// <summary>
        /// Draws an outline of <paramref name="rectangle"/>, with a tint of <paramref name="color"/>, a width of <paramref name="width"/>,
        /// and a depth of <paramref name="layer"/>.
        /// </summary>
        /// <param name="spriteBatch">This <see cref="SpriteBatch"/> instance</param>
        /// <param name="rectangle">The <see cref="Rectangle"/> to draw.</param>
        /// <param name="color">The <see cref="Color"/> of this line.</param>
        /// <param name="width">The width of this line.</param>
        /// <param name="layer">The depth of this line.</param>
        public static void DrawRectangle(
            this SpriteBatch spriteBatch,
            Rectangle rectangle,
            Color color,
            float width = 1,
            float layer = 0)
        {
            Vector2[] vertices = new Vector2[]
            {
                new Vector2(rectangle.Left, rectangle.Top),
                new Vector2(rectangle.Right, rectangle.Top),
                new Vector2(rectangle.Right, rectangle.Bottom),
                new Vector2(rectangle.Left, rectangle.Bottom)
            };

            for (int i = 0; i < vertices.Length - 1; i++)
            {
                DrawLine(spriteBatch, vertices[i], vertices[i + 1], color, width, layer);
            }
            DrawLine(spriteBatch, vertices[vertices.Length - 1], vertices[0], color, width, layer);
        }

        /// <summary>
        /// Draws an outline of a circle at <paramref name="center"/>, with a radius of <paramref name="radius"/>, with a tint
        /// of <paramref name="color"/>, with a width of <paramref name="width"/>, and a depth of <paramref name="depth"/>.
        /// </summary>
        /// <param name="spriteBatch">This <see cref="SpriteBatch"/> instance.</param>
        /// <param name="center">The center of the circle.</param>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="color">The <see cref="Color"/> of the circle</param>
        /// <param name="width">The width of the  circle.</param>
        /// <param name="precision">The amount of sides of the circle.</param>
        /// <param name="layer">The depth of the circle.</param>
        public static void DrawCircle(
            this SpriteBatch spriteBatch,
            Vector2 center,
            float radius,
            Color color,
            float width = 1,
            int precision = 16,
            float layer = 0)
        {
            Vector2[] vertices = new Vector2[precision];

            float increment = MathF.PI * 2.0f / precision;
            float theta = 0.0f;

            for (int i = 0; i < precision; i++)
            {
                vertices[i] = center + radius * new Vector2(MathF.Cos(theta), MathF.Sin(theta));
                theta += increment;
            }

            for (int i = 0; i < precision - 1; i++)
            {
                DrawLine(spriteBatch, vertices[i], vertices[i + 1], color, width, layer);
            }
            DrawLine(spriteBatch, vertices[precision - 1], vertices[0], color, width, layer);
        }
    }
}