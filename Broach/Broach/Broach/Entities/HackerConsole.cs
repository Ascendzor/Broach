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
                                position.Y = 0;
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
                        case ConsoleState.Down:

                            if (dt.TotalGameTime.Milliseconds % 100 == 0)
                            {
                                KeyboardState keys = Keyboard.GetState();
                                Keys[] allPressed = keys.GetPressedKeys();
                                bool isShiftModified = false;
                                if (keys.IsKeyDown(Keys.LeftShift) || keys.IsKeyDown(Keys.RightShift))
                                {
                                    isShiftModified = true;
                                }
                                for (int i = 0; i < allPressed.Length; i++)
                                {
                                    Keys someKey = allPressed[i];
                                    switch (someKey)
                                    {
                                        case Keys.Add:
                                            break;
                                        case Keys.Apps:
                                            break;
                                        case Keys.Attn:
                                            break;
                                        case Keys.Back:
                                            break;
                                        case Keys.BrowserBack:
                                            break;
                                        case Keys.BrowserFavorites:
                                            break;
                                        case Keys.BrowserForward:
                                            break;
                                        case Keys.BrowserHome:
                                            break;
                                        case Keys.BrowserRefresh:
                                            break;
                                        case Keys.BrowserSearch:
                                            break;
                                        case Keys.BrowserStop:
                                            break;
                                        case Keys.CapsLock:
                                            break;
                                        case Keys.ChatPadGreen:
                                            break;
                                        case Keys.ChatPadOrange:
                                            break;
                                        case Keys.Crsel:
                                            break;
                                        case Keys.D0:
                                            break;
                                        case Keys.D1:
                                            break;
                                        case Keys.D2:
                                            break;
                                        case Keys.D3:
                                            break;
                                        case Keys.D4:
                                            break;
                                        case Keys.D5:
                                            break;
                                        case Keys.D6:
                                            break;
                                        case Keys.D7:
                                            break;
                                        case Keys.D8:
                                            break;
                                        case Keys.D9:
                                            break;
                                        case Keys.Decimal:
                                            break;
                                        case Keys.Delete:
                                            break;
                                        case Keys.Divide:
                                            break;
                                        case Keys.Down:
                                            break;
                                        case Keys.End:
                                            break;
                                        case Keys.Enter:
                                            //newline yo
                                            break;
                                        case Keys.EraseEof:
                                            break;
                                        case Keys.Escape:
                                            break;
                                        case Keys.Execute:
                                            break;
                                        case Keys.Exsel:
                                            break;
                                        case Keys.F1:
                                            break;
                                        case Keys.F10:
                                            break;
                                        case Keys.F11:
                                            break;
                                        case Keys.F12:
                                            break;
                                        case Keys.F13:
                                            break;
                                        case Keys.F14:
                                            break;
                                        case Keys.F15:
                                            break;
                                        case Keys.F16:
                                            break;
                                        case Keys.F17:
                                            break;
                                        case Keys.F18:
                                            break;
                                        case Keys.F19:
                                            break;
                                        case Keys.F2:
                                            break;
                                        case Keys.F20:
                                            break;
                                        case Keys.F21:
                                            break;
                                        case Keys.F22:
                                            break;
                                        case Keys.F23:
                                            break;
                                        case Keys.F24:
                                            break;
                                        case Keys.F3:
                                            break;
                                        case Keys.F4:
                                            break;
                                        case Keys.F5:
                                            break;
                                        case Keys.F6:
                                            break;
                                        case Keys.F7:
                                            break;
                                        case Keys.F8:
                                            break;
                                        case Keys.F9:
                                            break;
                                        case Keys.Help:
                                            break;
                                        case Keys.Home:
                                            break;
                                        case Keys.ImeConvert:
                                            break;
                                        case Keys.ImeNoConvert:
                                            break;
                                        case Keys.Insert:
                                            break;
                                        case Keys.Kana:
                                            break;
                                        case Keys.Kanji:
                                            break;
                                        case Keys.LaunchApplication1:
                                            break;
                                        case Keys.LaunchApplication2:
                                            break;
                                        case Keys.LaunchMail:
                                            break;
                                        case Keys.Left:
                                            break;
                                        case Keys.LeftAlt:
                                            break;
                                        case Keys.LeftControl:
                                            break;
                                        case Keys.LeftShift:
                                            break;
                                        case Keys.LeftWindows:
                                            break;
                                        case Keys.MediaNextTrack:
                                            break;
                                        case Keys.MediaPlayPause:
                                            break;
                                        case Keys.MediaPreviousTrack:
                                            break;
                                        case Keys.MediaStop:
                                            break;
                                        case Keys.Multiply:
                                            break;
                                        case Keys.None:
                                            break;
                                        case Keys.NumLock:
                                            break;
                                        case Keys.NumPad0:
                                            break;
                                        case Keys.NumPad1:
                                            break;
                                        case Keys.NumPad2:
                                            break;
                                        case Keys.NumPad3:
                                            break;
                                        case Keys.NumPad4:
                                            break;
                                        case Keys.NumPad5:
                                            break;
                                        case Keys.NumPad6:
                                            break;
                                        case Keys.NumPad7:
                                            break;
                                        case Keys.NumPad8:
                                            break;
                                        case Keys.NumPad9:
                                            break;
                                        case Keys.Oem8:
                                            break;
                                        case Keys.OemAuto:
                                            break;
                                        case Keys.OemBackslash:
                                            break;
                                        case Keys.OemClear:
                                            break;
                                        case Keys.OemCloseBrackets:
                                            break;
                                        case Keys.OemComma:
                                            break;
                                        case Keys.OemCopy:
                                            break;
                                        case Keys.OemEnlW:
                                            break;
                                        case Keys.OemMinus:
                                            break;
                                        case Keys.OemOpenBrackets:
                                            break;
                                        case Keys.OemPeriod:
                                            break;
                                        case Keys.OemPipe:
                                            break;
                                        case Keys.OemPlus:
                                            break;
                                        case Keys.OemQuestion:
                                            break;
                                        case Keys.OemQuotes:
                                            break;
                                        case Keys.OemSemicolon:
                                            break;
                                        case Keys.OemTilde:
                                            break;
                                        case Keys.Pa1:
                                            break;
                                        case Keys.PageDown:
                                            break;
                                        case Keys.PageUp:
                                            break;
                                        case Keys.Pause:
                                            break;
                                        case Keys.Play:
                                            break;
                                        case Keys.Print:
                                            break;
                                        case Keys.PrintScreen:
                                            break;
                                        case Keys.ProcessKey:
                                            break;
                                        case Keys.Right:
                                            break;
                                        case Keys.RightAlt:
                                            break;
                                        case Keys.RightControl:
                                            break;
                                        case Keys.RightShift:
                                            break;
                                        case Keys.RightWindows:
                                            break;
                                        case Keys.Scroll:
                                            break;
                                        case Keys.Select:
                                            break;
                                        case Keys.SelectMedia:
                                            break;
                                        case Keys.Separator:
                                            break;
                                        case Keys.Sleep:
                                            break;
                                        case Keys.Space:
                                            s["consoleText"] += " ";
                                            break;
                                        case Keys.Subtract:
                                            break;
                                        case Keys.Tab:
                                            break;
                                        case Keys.VolumeDown:
                                            break;
                                        case Keys.VolumeMute:
                                            break;
                                        case Keys.VolumeUp:
                                            break;
                                        case Keys.Zoom:
                                            break;
                                        default:
                                            String chr = someKey.ToString();
                                            if (isShiftModified)
                                            {
                                                chr.ToLower();
                                            }
                                            s["consoleText"] += chr;
                                            break;
                                    }
                                }
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
