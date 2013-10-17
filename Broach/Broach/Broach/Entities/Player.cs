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
            Texture2D paddleTexture = game.Content.Load<Texture2D>("paddle");
            Rectangle renderRect = new Rectangle((int)position.X, (int)position.Y, paddleTexture.Width, paddleTexture.Height);
            RenderComponent paddleDrawer = new RenderComponent()
            {
                Draw = (SpriteBatch batch) =>
                {
                    batch.Draw(paddleTexture, renderRect, Color.White);
                },
            };
            this.Components.Add(paddleDrawer);
        }
    }
}
