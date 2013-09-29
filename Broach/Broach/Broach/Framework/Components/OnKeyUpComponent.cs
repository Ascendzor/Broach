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
    public class OnKeyUpComponent : GameComponent
    {
        private KeyState? previousState;
        private Action onClick;
        private Keys activeKey;

        public OnKeyUpComponent() {
            Game1.Systems["OnKeyUp"].Components.Add(this);
        }
        /// <summary>
        /// The key that will activate Onclick when it is lifted
        /// </summary>
        public Keys ActivationKey
        {
            get { return activeKey; }
            set { activeKey = value; }
        }
        
        /// <summary>
        /// this is a void returning method, that is called when the key is lifted
        /// </summary>
        public Action OnClick
        {
            get { return onClick; }
            set { onClick = value; }
        }
        
        /// <summary>
        /// active key state
        /// </summary>
        public KeyState? PreviousKeyState
        {
            get { return previousState; }
            set { previousState = value; }
        }
    }
}
