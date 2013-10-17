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



            Node newGameButton = new Button(new Vector2(100, 100), Content.Load<Texture2D>("NewGame"), newGameButtonClicked);
            nodes.Add(newGameButton);

        }

        public override void onEnter()
        {
            Console.WriteLine("Loaded the Main Menu scene");
        }

        public void newGameButtonClicked()
        {
        }
    }
}
