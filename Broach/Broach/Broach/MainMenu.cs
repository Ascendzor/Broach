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
    public class MainMenu : Scene
    {
        ContentManager Content;
        public MainMenu(ContentManager Content)
        {
            this.Content = Content;
            nodes = new List<Node>();

            Node menuLabel = new Label(this, new Vector2(20, 20), Content.Load<Texture2D>("MainMenuLabel"));
            nodes.Add(menuLabel);

            Node newGameButton = new Button(this, new Vector2(100, 100), Content.Load<Texture2D>("NewGame"), newGameButtonClicked);
            nodes.Add(newGameButton);

            Node continueButton = new Button(this, new Vector2(500, 100), Content.Load<Texture2D>("Continue"), continueButtonClicked);
            nodes.Add(continueButton);

            Node exitButton = new Button(this, new Vector2(300, 300), Content.Load<Texture2D>("Exit"), exitButtonClicked);
            nodes.Add(exitButton);
        }

        public override void onEnter()
        {
            Console.WriteLine("Loaded the Main Menu scene");
        }
        public void newGameButtonClicked()
        {
            Game1.SceneController.Handle(SceneFactory.getNewGame(Content));
        }

        public void continueButtonClicked()
        {
            Game1.SceneController.Handle(SceneFactory.getContinueScene(Content));
        }

        public void exitButtonClicked()
        {
            Console.WriteLine("exit");
        }
    }
}
