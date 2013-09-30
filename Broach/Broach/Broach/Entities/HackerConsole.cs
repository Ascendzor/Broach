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
    enum ConsoleState
    {
        Down,
        Up,
        GoingDown,
        GoingUp
    }
    /// <summary>
    /// The hacker console is yr typical drop down console which allows interaction with the system
    /// </summary>
    class HackerConsole : Node
    {

        // Note, its not good to store state in a node
        // State stored in a node won't be accessable by components
        SpriteFont font;
        
        public HackerConsole(ContentManager Content)
        {

            // State that will be accessble through hackerconsoles script component
            Dictionary<String, object> hackerstate = new Dictionary<string,object>()
            {
                {"consolePosition", new Vector2(110, -200)},
                {"consoleText", "Bro@ch >"},
                {"state", ConsoleState.Up},
            };

            ScriptComponent hackerConsoleState = new ScriptComponent()
            {
                Data = hackerstate,
                UpdateAction = (GameTime dt, object state) => {
                    Dictionary<String, object> s = (Dictionary<String, object>)state;
                    Vector2 position = (Vector2)s["consolePosition"];
                    Vector2 criticalValue = new Vector2(110,177);

                    float speed = 10f;
                    ConsoleState console = (ConsoleState)s["state"];
                    switch (console)
                    {
                        case ConsoleState.GoingDown:
                            position.Y = position.Y + speed;
                            if (position.Y > 0)
                            {
                                console = ConsoleState.Down;
                            }
                            break;
                        case ConsoleState.GoingUp:
                            position.Y = position.Y - speed;
                            if (position.Y < -200 )
                            {
                                console = ConsoleState.Up;
                            }
                            break;
                        default:
                            break;
                    }
                    s["consolePosition"] = position;
                    s["state"] = console;
                }
            };
            Components.Add(hackerConsoleState);
            

            // binding for opening the console
            OnKeyUpComponent activator = new OnKeyUpComponent()
            {
                ActivationKey = Keys.OemTilde,
                OnClick = () => {
                    ConsoleState s = (ConsoleState)hackerstate["state"];
                    if (s == ConsoleState.Up)
                    {
                        s = ConsoleState.GoingDown;
                    }
                    else if (s == ConsoleState.Down)
                    {
                        s = ConsoleState.GoingUp;
                    }
                    hackerstate["state"] = s;
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
            font = Content.Load<SpriteFont>("SpriteFont1");

            RenderComponent visibleStuff = new RenderComponent()
            {
                Draw = (SpriteBatch batch) =>
                {
                    ConsoleState s = (ConsoleState)hackerstate["state"];
                    Vector2 p = (Vector2)hackerstate["consolePosition"];
                    Vector2 textPosition = p + new Vector2(0,177);
                    Rectangle renderRect = new Rectangle((int)p.X, (int)p.Y, tex.Bounds.Width, tex.Bounds.Height);
                    batch.Draw(tex, renderRect, Color.White);
                    batch.DrawString(font, (string)hackerstate["consoleText"], (Vector2) hackerstate["consolePosition"], Color.White);
                }
            };
            Components.Add(visibleStuff);

            /*
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
                            if ((bool)hackerstate["isActive"])
                            {
                                consoleData += key.ToString();
                            }
                        }
                    };
                    Components.Add(key_listener);
                }
            }
            */
        }
    }
}
