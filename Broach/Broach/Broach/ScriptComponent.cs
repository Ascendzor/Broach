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

    public class ScriptComponent
    {
        private Action<GameTime, object> updateFn;

        private object data;

        /// <summary>
        /// The data context which is passed into updateFn
        /// </summary>
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// called every frame, takes the timedelta for the frame and the object which is the data context for this update component
        /// </summary>
        public Action<GameTime, object> UpdateAction
        {
            get { return updateFn; }
            set { updateFn = value; }
        }
        
    }
}
