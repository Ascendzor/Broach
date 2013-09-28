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
        public SpriteSystem(SpriteBatch batch)
        {
            if (batch == null)
                throw new ArgumentNullException();
            else
            {
                this.batch = batch;
                sprites = new List<SpriteComponent>();
            }
        }


        private List<SpriteComponent> sprites;

        public List<SpriteComponent> Sprites
        {
            get { return sprites; }
            set { sprites = value; }
        }

        public override void Update(GameTime gameTime)
        {
            batch.Begin();
            foreach (SpriteComponent item in sprites)
            {
                item.Draw(batch);
            }
            batch.End();
        }

        /// <summary>
        /// clears all components, nothing will be rendered
        /// </summary>
        public override void Clear()
        {
            sprites = new List<SpriteComponent>();
        }
    }
}
