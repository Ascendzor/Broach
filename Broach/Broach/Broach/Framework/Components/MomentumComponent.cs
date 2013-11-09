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
    class MomentumComponent : GameComponent
    {
        private PositionComponent positionComponent;
        private Vector2 velocity;

        public PositionComponent PositionComponent
        {
            get { return positionComponent; }
            set { positionComponent = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public MomentumComponent(PositionComponent positionComponent, Vector2 velocity)
        {
            this.positionComponent = positionComponent;
            this.velocity = velocity;

            Game1.Systems["Momentum"].Components.Add(this);
        }
    }
}
