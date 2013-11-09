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
    class MomentumSystem : GameSystem
    {
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (MomentumComponent momentumComponent in Components)
            {
                Vector2 myPosition = ((MomentumComponent)momentumComponent).PositionComponent.Position;
                ((MomentumComponent)momentumComponent).PositionComponent.Position = new Vector2(myPosition.X + momentumComponent.Velocity.X, myPosition.Y + momentumComponent.Velocity.Y);
            }
        }
    }
}
