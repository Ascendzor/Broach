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
    /// <summary>
    /// The hacker console is yr typical drop down console which allows interaction with the system
    /// </summary>
    class HackerConsole : Node
    {

        SpriteFont font;
        Vector2 inputTextPosition;
        String consoleData;


        
        public HackerConsole(ContentManager Content)
        {

            ScriptComponent isActive = new ScriptComponent()
            {
                Data = false,
                UpdateAction = (GameTime dt, object data) => {}
            };
            Components.Add(isActive);

            // binding for opening the console
            OnKeyUpComponent activator = new OnKeyUpComponent()
            {
                ActivationKey = Keys.OemTilde,
                OnClick = () => {
                    if ((bool)isActive.Data)
                    {
                        Console.Out.WriteLine("Toggled off!");
                        isActive.Data = false;
                    }
                    else
                    {
                        Console.Out.WriteLine("Toggled on!");
                        isActive.Data = true;
                    }
                }
            };
            Components.Add(activator);

            // What other components need to be made?
            // Draw background
            Texture2D tex  = Content.Load<Texture2D>("bg");
            RenderComponent background = new RenderComponent()
            {
                Draw = (SpriteBatch batch) =>
                {
                    batch.Draw(tex, new Rectangle(100,0,tex.Bounds.Width,tex.Bounds.Height),Color.White);
                }
            };
            Components.Add(background);
            // animate background into vision

            // Draw text
            // Its a hacker console so this will be a hacker solution :)
            // draw text through a scriptComponent

            consoleData = "Bro@ch > ";
            inputTextPosition = new Vector2(110, 177);
            font = Content.Load<SpriteFont>("SpriteFont1");
            RenderComponent textInput = new RenderComponent()
            {
                Draw = (SpriteBatch batch) =>
                {
                    batch.DrawString(font, consoleData, inputTextPosition, Color.White);
                }
            };
            Components.Add(textInput);

        }

        private void drawTextContent(GameTime dt, object data) {
            String content = (string)data;
            //spritebatch reference... 
            // this is ineffcient but fuck it...
            Game1.Batch.Begin();
            Game1.Batch.DrawString(font, content, inputTextPosition,Color.Wheat);
            Game1.Batch.End();

        }
    }
}
