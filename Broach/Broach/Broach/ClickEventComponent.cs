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
        private Rectangle target;

        public Rectangle Target
        {
            get { return target; }
            set { target = value; }
        }
        

        private Action onClick;

        public Action OnClick
        {
            get { return onClick; }
            set { onClick = value; }
        }
        
        public ClickEventComponent(Action onclick, Rectangle target)
        {
            if (onclick == null ||target == null)
            {
                throw new ArgumentNullException();
            }
            onClick = onclick;
            this.target = target;

            // add self to the clicksystem aspect
            Game1.ClickSystem.ClickEvents.Add(this);
        }
    }
}
