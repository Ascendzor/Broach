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

namespace Broach
{
    public class SceneFactory
    {
        
        private static void prepSceneForDispatch() 
        {
            foreach (GameSystem system in Game1.Systems)
            {
                system.Clear();
            }
        }
        public static Scene getNewGame(ContentManager Content)
        {
            prepSceneForDispatch();
            Scene scene = new NewGame(Content);
            return scene;
        }

        public static Scene getMainMenu(ContentManager Content)
        {
            prepSceneForDispatch();
            Scene scene = new MainMenu(Content);
            return scene; 
        }

        public static Scene getContinueScene(ContentManager Content)
        {
            prepSceneForDispatch();
            Scene scene = new Continue(Content);
            return scene;
        }
    }
}
