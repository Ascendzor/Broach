using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broach
{
    public class SceneSystem
    {
        private Scene activeScene;
        private Scene nextScene;


        /// <summary>
        /// Load a scene after all the other entities have had there components updated.
        /// </summary>
        /// <param name="a"></param>
        public void Handle(Scene a)
        {
            if (activeScene == null)
            {
                activeScene = a;
            }
            else
            {
                nextScene = a;
            }
        }

        /// <summary>
        /// Update method, only does stuff when there is a next scene
        /// </summary>
        public void Update()
        {
            if (nextScene != null)
            {
                activeScene = nextScene;
                nextScene = null;
            }
        }
    }
}
