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
    class Label : Node
    {
        public Label(object parent, Vector2 position, Texture2D texture)
        {
            Rectangle buttonSize = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); 
            SpriteComponent buttonSprite = new SpriteComponent(this, texture, buttonSize);
            Components.Add(buttonSprite);
        }
    }
}
