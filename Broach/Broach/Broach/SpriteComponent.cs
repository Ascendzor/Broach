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
    public class SpriteComponent : GameComponent
    {
        private Texture2D texture;
        private Rectangle renderRect;
        private bool isVisible;

        public bool IsVisisble
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        

        /// <summary>
        /// creates a sprite component, this draws the given texture at the supposed rectangle
        /// </summary>
        /// <param name="tex"> texture which will be drawn</param>
        /// <param name="r"> where it will be drawm, and how large it will be drawn</param>
        public SpriteComponent(Node parent, Texture2D tex, Rectangle r)
        {
            texture = tex;
            renderRect = r;
            isVisible = true;

            // add oneself to the SpriteSystem.
            Game1.SpriteRenderer.Sprites.Add(this);
        }
        public void Draw(SpriteBatch b)
        {
            if (isVisible)
            {
                b.Draw(texture, renderRect, Color.White);
            }
        }
    }
}
