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

namespace Broach
{
    class Button : Node
    {
        public Button(object parent, Vector2 position, Texture2D texture, Action clickAction)
        {
            // Add the Sprite component
            Rectangle buttonSize = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); 
            SpriteComponent buttonSprite = new SpriteComponent(this, texture, buttonSize);
            Components.Add(buttonSprite);

            // add the click component
            ClickEventComponent clickClak = new ClickEventComponent(clickAction, buttonSize);
            Components.Add(clickClak);
        }
    }
}
