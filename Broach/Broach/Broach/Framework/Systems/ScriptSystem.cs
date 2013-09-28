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
        private List<ScriptComponent> scripts;

        public List<ScriptComponent> Scripts
        {
            get { return scripts; }
            set { scripts = value; }
        }
        public ScriptSystem()
        {
            scripts = new List<ScriptComponent>();
        }

        public override void Update(GameTime dt)
        {
            foreach (var item in scripts)
            {
                item.UpdateAction(dt, item.Data);
            }
        }

        public override void AddComponent(GameComponent component)
        {
            scripts.Add((ScriptComponent)component);
        }

        public override void Clear() {
            scripts = new List<ScriptComponent>();
        }
        
    }
}
