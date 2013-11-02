using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Broach
{
    public class RenderComponent : GenericRenderComponent
    {
        private Texture2D tex;
        private PositionComponent positionComponent;
        private Vector2 position;

        /// <summary>
        /// creates a sprite component, this draws the given texture at the supposed rectangle
        /// </summary>
        /// <param name="tex"> texture which will be drawn</param>
        /// <param name="r"> where it will be drawm, and how large it will be drawn</param>
        public RenderComponent(Texture2D tex, PositionComponent positionComponent)
        {
            this.positionComponent = positionComponent;
            this.tex = tex;
            // add oneself to the SpriteSystem.
            Game1.Systems["Render"].Components.Add(this);
        }
        public override void Draw( SpriteBatch batch )
        {
            batch.Draw(tex, positionComponent.Position, Color.White);
        }
    }
}
