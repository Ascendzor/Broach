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
            float velocity = 20;

            Dictionary<Keys, Action> keysToActions = new Dictionary<Keys, Action>();
            Action aKey = () =>
            {
                Vector2 myPosition = ((PositionComponent)me.Components["PositionComponent"]).Position;
                ((PositionComponent)me.Components["PositionComponent"]).Position = new Vector2(myPosition.X, myPosition.Y - velocity);
            };

            Action zKey = () =>
            {
                Vector2 myPosition = ((PositionComponent)me.Components["PositionComponent"]).Position;
                ((PositionComponent)me.Components["PositionComponent"]).Position = new Vector2(myPosition.X, myPosition.Y + velocity);
            };

            keysToActions.Add(Keys.A, aKey);
            keysToActions.Add(Keys.Z, zKey);

            OnKeyUpComponent onKeysUp = new OnKeyUpComponent(keysToActions);
            me.Components.Add("OnKeyUpComponent", onKeysUp);
            
            // make me respond to mouse input
            Player you = new Player(game, new Vector2(game.GraphicsDevice.Viewport.Width - 13 - 10, 100));
            you.Components.Add("ScriptComponent", new ScriptComponent()
            {
                UpdateAction = (GameTime dt, object data) => 
                {
                    MouseState mouse = Mouse.GetState();
                    Vector2 myPosition = ((PositionComponent)you.Components["PositionComponent"]).Position;
                    ((PositionComponent)you.Components["PositionComponent"]).Position = new Vector2(myPosition.X, mouse.Y);
                }
            });
        }
        public override void onEnter()
        {
            throw new NotImplementedException();
        }
    }
}
