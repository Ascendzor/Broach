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
            float velocity = 10;
            OnKeyUpComponent moveup = new OnKeyUpComponent(){
                ActivationKey = Keys.A,
                OnClick = () => {
                    foreach (var item in me.Components)
                    {
                        if (item is PositionComponent)
                        {
                            PositionComponent c = (PositionComponent)item;
                            c.Position = new Vector2(c.Position.X, c.Position.Y - velocity);
                        }
                    }
                },
            };
            me.Components.Add(moveup);
            OnKeyUpComponent moveDown = new OnKeyUpComponent(){
                ActivationKey = Keys.Z,
                OnClick = () => {
                    foreach (var item in me.Components)
                    {
                        if (item is PositionComponent)
                        {
                            PositionComponent c = (PositionComponent)item;
                            c.Position = new Vector2(c.Position.X, c.Position.Y + velocity);
                        }
                    }
                },
            };
            me.Components.Add(moveDown);
            
            // make me respond to mouse input
            Player you = new Player(game, new Vector2(game.GraphicsDevice.Viewport.Width - 13 - 10, 100));
            you.Components.Add(new ScriptComponent()
            {
                UpdateAction = (GameTime dt, object data) => 
                {
                    MouseState mouse = Mouse.GetState();
                    foreach (var item in you.Components)
                    {
                        if (item is PositionComponent)
                        {
                            PositionComponent c = (PositionComponent)item;
                            c.Position = new Vector2(c.Position.X, mouse.Y);
                            
                        }
                    }
                }
            });
        }
        public override void onEnter()
        {
            throw new NotImplementedException();
        }
    }
}
