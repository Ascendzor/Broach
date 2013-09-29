﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;
namespace Broach
{
    public abstract class GameSystem
    {
        private List<GameComponent> components = new List<GameComponent>();

        public List<GameComponent> Components
        {
            get { return components; }
            set { components = value; }
        }
        
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Clears the set of components the system currently updates
        /// </summary>
        public void Clear()
        {
            components = new List<GameComponent>();
        }
    }
}
