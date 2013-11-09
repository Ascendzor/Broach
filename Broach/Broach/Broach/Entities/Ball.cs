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
    class Ball : Node
    {
        public Ball(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            Components.Add("PositionComponent", new PositionComponent(position));
            Components.Add("RenderComponent", new RenderComponent(texture, (PositionComponent)Components["PositionComponent"]));
        }
    }
}
