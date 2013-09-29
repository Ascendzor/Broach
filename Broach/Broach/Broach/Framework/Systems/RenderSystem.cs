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
    public class RenderSystem : GameSystem
    {
        private SpriteBatch batch;
        private List<RenderComponent> sprites;

        /// <summary>
        /// spritesystem is the subsystem of a game which draws EVEERY single 2d texture in the game.
        /// </summary>
        /// <param name="batch"></param>
        public RenderSystem(SpriteBatch b)
        {
            batch = b;
        }

        public override void Update(GameTime gameTime)
        {
            batch.Begin();
            foreach (RenderComponent item in sprites)
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

