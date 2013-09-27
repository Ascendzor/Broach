using System;
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

namespace Broach
{
    public class Node
    {
        private List<GameComponent> components;

        public List<GameComponent> Components
        {
            get { return components; }
            set { components = value; }
        }
        
        public Node()
        {
            components = new List<GameComponent>();
        }
    }
}
