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
    class Walls : Node
    {
        public Walls(Game1 game)
        {
            Texture2D wallsTexture = game.Content.Load<Texture2D>("pong_bg");
            Rectangle renderRect = new Rectangle(0, 0, wallsTexture.Width, wallsTexture.Height);
            PositionComponent pc = new PositionComponent(new Vector2(0,0));
            RenderComponent paddleDrawer = new RenderComponent(wallsTexture, pc);
            this.Components.Add(paddleDrawer);
                
            
        }
    }
}
