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
    public class RenderComponent : GameComponent
    {
        private bool isVisible;
        private Action<SpriteBatch> draw;

        public Action<SpriteBatch> Draw
        {
            get { return draw; }
            set { draw = value; }
        }
        

        public bool IsVisisble
        {
            get {
                return isVisible;
            }
            set { isVisible = value; }
        }
        

        /// <summary>
        /// creates a sprite component, this draws the given texture at the supposed rectangle
        /// </summary>
        /// <param name="tex"> texture which will be drawn</param>
        /// <param name="r"> where it will be drawm, and how large it will be drawn</param>
        public RenderComponent()
        {
            isVisible = true;
            // add oneself to the SpriteSystem.
            Game1.Systems["Render"].Components.Add(this);
        }
    }
}
