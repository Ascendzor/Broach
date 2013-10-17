
﻿using System;
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
            foreach (string key in Game1.Systems.Keys)
            {
                Game1.Systems[key].Clear();
            }
        }
        public static Scene getNewGame(ContentManager Content, Game1 game)
        {
            prepSceneForDispatch();
            Scene scene = new GameScene(Content, game);
            return scene;
        }
    }
}
