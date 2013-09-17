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
    public class SceneManager
    {
        public static void handleNewGame(ContentManager Content)
        {
            Game1.scene = new NewGame(Content);
        }

        public static void handleMainMenu(ContentManager Content)
        {
            Game1.scene = new MainMenu(Content);
        }

        public static void handleContinue(ContentManager Content)
        {
            Game1.scene = new Continue(Content);
        }
    }
}
