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
    public class ClickEventSystem : GameSystem
    {
        public override void Update(GameTime gameTime)
        {
            foreach (ClickEventComponent click in Components)
            {
                MouseState mouse = Mouse.GetState();
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (mouse.X > click.Target.X && mouse.X < click.Target.X + click.Target.Width)
                    {
                        if (mouse.Y > click.Target.Y && mouse.Y < click.Target.Y + click.Target.Height)
                        {
                            click.OnClick();
                        }

                    }
                }   
            }
        }
    }
}
