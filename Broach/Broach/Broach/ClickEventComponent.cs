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
    public class ClickEventComponent : GameComponent
    {
        private Action onClick;
        private Rectangle target;

        public Action OnClick
        {
            get { return onClick; }
        }

        public Rectangle Target
        {
            get { return target; }
        }

        public ClickEventComponent(Action onClick, Rectangle target)
        {
            this.onClick = onClick;
            this.target = target;

            Game1.ClickSystem.ClickComponents.Add(this);
        }
    }
}
