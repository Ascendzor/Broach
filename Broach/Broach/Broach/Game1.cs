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

        // list to easily iterate through all systems
        public static List<GameSystem> Systems = new List<GameSystem>();

        // scene aspect updates the scene after any other updates have happened
        public static SceneSystem SceneController;

        // renderer aspect
        public static SpriteSystem SpriteRenderer;

        // click event aspect
        public static ClickEventSystem ClickSystem;

        public static OnKeyUpSystem KeyUpSystem;

        public static ScriptSystem scriptSystem;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ((Form)Form.FromHandle(this.Window.Handle)).Cursor = System.Windows.Forms.Cursors.Cross;

            IsMouseVisible = true;

            Systems.Add(SpriteRenderer = new SpriteSystem(new SpriteBatch(GraphicsDevice)));
            Systems.Add(ClickSystem = new ClickEventSystem());
            Systems.Add(KeyUpSystem = new OnKeyUpSystem());
            Systems.Add(scriptSystem = new ScriptSystem());

            SceneController = new SceneSystem();
            SceneController.Handle(SceneFactory.getMainMenu(Content));

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameSystem system in Systems)
            {
                system.Update(gameTime);
            }
            SceneController.Update();

            base.Update(gameTime);
        }


        //potentially made irrelevant
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
