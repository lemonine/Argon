using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Argon
{
    /// <summary>
    /// A struct that contains <see cref="SpriteBatch.Begin(SpriteSortMode, BlendState,
    /// SamplerState, DepthStencilState, RasterizerState, Effect, Matrix?)"/> parameters.
    /// </summary>
    public struct SpriteBatchParameters
    {
        public SpriteSortMode sortMode;
        public BlendState blendState;
        public SamplerState samplerState;
        public DepthStencilState depthStencilState;
        public RasterizerState rasterizerState;
        public Effect effect;
        public Matrix? transformMatrix;

        public SpriteBatchParameters(
            SpriteSortMode _sortMode = SpriteSortMode.Deferred,
            BlendState _blendState = null,
            SamplerState _samplerState = null,
            DepthStencilState _depthStencilState = null,
            RasterizerState _rasterizerState = null,
            Effect _effect = null,
            Matrix? _transformMatrix = null)
        {
            sortMode = _sortMode;
            blendState = _blendState;
            samplerState = _samplerState;
            depthStencilState = _depthStencilState;
            rasterizerState = _rasterizerState;
            effect = _effect;
            transformMatrix = _transformMatrix;
        }
    }
}
