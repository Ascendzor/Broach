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
    class HackerConsole : Node
    {
        public HackerConsole()
        {

            ScriptComponent isActive = new ScriptComponent()
            {
                Data = false,
                UpdateAction = (GameTime dt, object data) => {}
            };

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

        }
    }
}
