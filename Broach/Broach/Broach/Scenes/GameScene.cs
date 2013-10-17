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
    class GameScene : Scene
    {
        public GameScene(ContentManager content, Game1 game)
        {
            Walls bg = new Walls(game);
            Player me = new Player(game, new Vector2(10,100));
            // make me respond to mouse input
            me.Components.Add(new ScriptComponent()
            {
                UpdateAction = (GameTime dt, object data) => 
                {
                    MouseState mouse = Mouse.GetState();
                }
            });
            Player you = new Player(game, new Vector2(game.GraphicsDevice.Viewport.Width - 13 - 10, 100));
        }
        public override void onEnter()
        {
            throw new NotImplementedException();
        }
    }
}
