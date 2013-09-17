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
        Action clickAction;
        public Button(object parent, Vector2 position, Texture2D texture, Action clickAction)
        {
            this.parent = parent;
            this.position = position;
            this.texture = texture;
            this.clickAction = clickAction;
        }

        public override void update()
        {
            //on mouse click
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //check if the click inside the texture of the button
                if((Mouse.GetState().X > position.X) && (Mouse.GetState().X < (position.X+texture.Width)) && (Mouse.GetState().Y > position.Y) && (Mouse.GetState().Y < (position.Y+texture.Height)))
                {
                    clickAction();
                }
            }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
