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
        private Dictionary<Keys, KeyState?> previousStates;
        private Dictionary<Keys, Action> keyActionMap;

        public OnKeyUpComponent(Dictionary<Keys, Action> keyActionMap) {
            Game1.Systems["OnKeyUp"].Components.Add(this);

            this.keyActionMap = keyActionMap;

            this.previousStates = new Dictionary<Keys, KeyState?>();
            foreach (Keys leKey in keyActionMap.Keys)
            {
                this.previousStates.Add(leKey, null);
            }
        }

        public Dictionary<Keys, Action> KeyActionMap
        {
            get { return keyActionMap; }
            set { keyActionMap = value; }
        }
        
        /// <summary>
        /// active key state
        /// </summary>
        public Dictionary<Keys, KeyState?> PreviousKeyStates
        {
            get { return previousStates; }
            set { previousStates = value; }
        }
    }
}
