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
        Game1 game;
        public MainMenu(ContentManager Content, Game1 game)
        {
            this.Content = Content;
            this.game = game;
            nodes = new List<Node>();

            game.IsMouseVisible = true;
            Node newGameButton = new Button(this, new Vector2(300, 300), Content.Load<Texture2D>("NewGame"), newGameButtonClicked);
            nodes.Add(newGameButton);
        }

        public void newGameButtonClicked()
        {
            Game1.SceneController.Handle(SceneFactory.getNewGame(Content, game));
        }
    }
}
