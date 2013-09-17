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
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;

namespace Broach
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Scene scene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ((Form)Form.FromHandle(this.Window.Handle)).Cursor = System.Windows.Forms.Cursors.Cross;

            IsMouseVisible = true;
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scene = new MainMenu(Content);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            scene.update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            scene.draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
