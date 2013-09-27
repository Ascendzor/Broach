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
        // renderer aspect
        public static SpriteSystem SpriteRenderer;

        // click event aspect
        public static ClickEventSystem ClickSystem;

        // scene aspect updates the scene after any other updates have happened
        public static SceneSystem SceneController;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ((Form)Form.FromHandle(this.Window.Handle)).Cursor = System.Windows.Forms.Cursors.Cross;

            IsMouseVisible = true;
            SpriteRenderer = new SpriteSystem(new SpriteBatch(GraphicsDevice));
            SceneController = new SceneSystem();
            ClickSystem = new ClickEventSystem();
            SceneController.Handle(SceneFactory.getMainMenu(Content));

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            ClickSystem.Update();
            SceneController.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteRenderer.Draw();
            base.Draw(gameTime);
        }
    }
}
