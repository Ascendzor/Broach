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
            foreach (OnKeyUpComponent item in Components)
            {
                KeyboardState curr = Keyboard.GetState();
                KeyState currentKeyState = curr.IsKeyDown(item.ActivationKey) ? KeyState.Down: KeyState.Up;

                // if we have no previous state it is not possible for the key to be activated, set previous and gtfo
                if (item.PreviousKeyState == null)
                    item.PreviousKeyState = currentKeyState;
                else
                {
                    if (currentKeyState == KeyState.Up && item.PreviousKeyState == KeyState.Down)
                    {
                        item.OnClick();
                    }
                    item.PreviousKeyState = currentKeyState;
                }
            }
        }
    }
}

