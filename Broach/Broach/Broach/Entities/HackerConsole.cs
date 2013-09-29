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

        // Note, its not good to store state in a node
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
            
            // animate background into vision

            // Draw text
            // Its a hacker console so this will be a hacker solution :)
            // draw text through a scriptComponent

            // Draw background
            Texture2D tex  = Content.Load<Texture2D>("bg");
            consoleData = "Bro@ch > ";
            inputTextPosition = new Vector2(110, 177);
            font = Content.Load<SpriteFont>("SpriteFont1");
            RenderComponent visibleStuff = new RenderComponent()
            {
                Draw = (SpriteBatch batch) =>
                {
                    if ((bool)isActive.Data)
                    {
                        batch.Draw(tex, new Rectangle(100,0,tex.Bounds.Width,tex.Bounds.Height),Color.White);
                        batch.DrawString(font, consoleData, inputTextPosition, Color.White);
                    }
                }
            };
            Components.Add(visibleStuff);

            // make events for each keypress to get keyboard input
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                // tilde reserved for toggling the console
                if (key != Keys.OemTilde)
                {
                    // binding for opening the console
                    OnKeyUpComponent key_listener = new OnKeyUpComponent()
                    {
                        ActivationKey = key,
                        OnClick = () => {
                            if ((bool)isActive.Data)
                            {
                                consoleData += key.ToString();
                            }
                        }
                    };
                    Components.Add(key_listener);
                }
                
            }
        }
    }
}
