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
    /// A Game component which makes the entity respond to mouse click being pressed while targeted in the given coordinates
    /// </summary>
    class ClickEventComponent : GameComponent
    {
        private Action onClick;
        private Rectangle target;
        public ClickEventComponent(Action onclick, Rectangle target)
        {
            onClick = onclick;
            this.target = target;
        }
        public override void Update()
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.X > target.X && mouse.X < target.X + target.Width)
            {
                if (mouse.Y > target.Y && mouse.Y < target.Y + target.Height)
                {
                    onClick();
                }
                
            }
        }
    }
}
