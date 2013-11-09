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
    public class OnKeyUpSystem : GameSystem
    {
        public override void Update(GameTime gameTime)
        {
            KeyboardState current = Keyboard.GetState();
                        
            foreach (OnKeyUpComponent item in Components)
            {
                foreach (Keys leKey in item.KeyActionMap.Keys)
                {
                    KeyState currentKeyState = current.IsKeyDown(leKey) ? KeyState.Down : KeyState.Up;
                    if (item.PreviousKeyStates[leKey] == null)
                    {
                        item.PreviousKeyStates[leKey] = currentKeyState;
                    }
                    else
                    {
                        if (currentKeyState == KeyState.Up && item.PreviousKeyStates[leKey] == KeyState.Down)
                        {
                            Console.WriteLine("asdf");
                            item.KeyActionMap[leKey]();
                        }
                        item.PreviousKeyStates[leKey] = currentKeyState;
                    }
                }
            }
        }
    }
}

