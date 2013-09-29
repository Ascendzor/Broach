using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Broach
{
    public class ScriptSystem : GameSystem
    {
        public override void Update(GameTime dt)
        {
            foreach (ScriptComponent item in Components)
            {
                item.UpdateAction(dt, item.Data);
            }
        }
    }
}
