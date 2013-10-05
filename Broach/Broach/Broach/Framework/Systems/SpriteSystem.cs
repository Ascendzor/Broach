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
    public class SpriteSystem : GameSystem
    {
        private SpriteBatch batch;

        /// <summary>
        /// spritesystem is the subsystem of a game which draws EVEERY single 2d texture in the game.
        /// </summary>
        /// <param name="batch"></param>
        public SpriteSystem(SpriteBatch b)
        {
            batch = b;
        }

        public override void Update(GameTime gameTime)
        {
            if (Components.Count == 0 )
            {
                return;
            }

            batch.Begin();
            foreach (SpriteComponent item in Components)
            {
                if (item.IsVisisble)
                {
                    item.Draw(batch);
                }
            }
            batch.End();
        }

    }
}

