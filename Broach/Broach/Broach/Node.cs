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
    public abstract class Node
    {
        protected object parent;
        protected Vector2 position;
        protected Texture2D texture;

        public abstract void update();

        public abstract void draw(SpriteBatch spriteBatch);
    }
}
