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
    class Player : Node 
    {
        public Player(Game1 game, Vector2 position)
        {

            PositionComponent paddle = new PositionComponent(position);
            this.Components.Add(paddle);

            Texture2D paddleTexture = game.Content.Load<Texture2D>("paddle");
            RenderComponent paddleDrawer = new RenderComponent(paddleTexture, paddle);
            this.Components.Add(paddleDrawer);
        }
    }
}
