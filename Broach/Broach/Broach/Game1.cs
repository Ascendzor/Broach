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
using System.Collections;

namespace Broach
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        // list to easily iterate through all systems
        public static Dictionary<string, GameSystem> Systems;

        // scene aspect updates the scene after any other updates have happened
        public static SceneController SceneController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ((Form)Form.FromHandle(this.Window.Handle)).Cursor = System.Windows.Forms.Cursors.Cross;

            IsMouseVisible = true;

            Systems = new Dictionary<string, GameSystem>();
            Systems.Add("Sprite", new RenderSystem(new SpriteBatch(GraphicsDevice)));
            Systems.Add("ClickEvent", new ClickEventSystem());
            Systems.Add("OnKeyUp", new OnKeyUpSystem());
            Systems.Add("Script", new ScriptSystem());

            SceneController = new SceneController();
            SceneController.Handle(SceneFactory.getMainMenu(Content));

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (string system in Systems.Keys)
            {
                Systems[system].Update(gameTime);
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
