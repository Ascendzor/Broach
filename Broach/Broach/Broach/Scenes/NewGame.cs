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
    class NewGame : Scene
    {
        private ContentManager Content;

        public NewGame(ContentManager Content)
        {
            this.Content = Content;
            nodes = new List<Node>();

            Node menuLabel = new Label(this, new Vector2(20, 20), Content.Load<Texture2D>("NewGameLabel"));
            nodes.Add(menuLabel);

            Button mainMenuButton = new Button(this, new Vector2(100, 400), Content.Load <Texture2D>("MainMenuLabel"), mainMenuButtonclicked);
            nodes.Add(mainMenuButton);
        }

        public override void onEnter()
        {
            Console.WriteLine("Entered the newgame scene");
        }
        public void mainMenuButtonclicked()
        {
            SceneFactory.getMainMenu(Content);
        }
    }
}
