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
    public class ClickSystem
    {
        /// <summary>
        /// ClickSystem is the subsystem of a game which handles the clicking of the object including both click detection and click reaction.
        /// </summary>
        /// <param name="batch"></param>
        public ClickSystem()
        {
            clickComponents = new List<ClickEventComponent>();
        }


        private List<ClickEventComponent> clickComponents;

        public List<ClickEventComponent> ClickComponents
        {
            get { return clickComponents; }
            set { clickComponents = value; }
        }

        public void Update()
        {
            foreach (ClickEventComponent clickComponent in clickComponents)
            {
                MouseState mouse = Mouse.GetState();
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (mouse.X > clickComponent.Target.X && mouse.X < clickComponent.Target.X + clickComponent.Target.Width)
                    {
                        if (mouse.Y > clickComponent.Target.Y && mouse.Y < clickComponent.Target.Y + clickComponent.Target.Height)
                        {
                            clickComponent.OnClick();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// clears all components, nothing will be rendered
        /// </summary>
        public void Clear()
        {
            clickComponents = new List<ClickEventComponent>();
        }
    }
}
