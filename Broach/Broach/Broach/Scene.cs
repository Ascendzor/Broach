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
    public abstract class Scene
    {
        protected Game1 parent;
        protected List<Node> nodes;
        
        public void Update()
        {
            foreach (Node node in nodes)
            {
                node.Update();
            }
        }
    }
}
