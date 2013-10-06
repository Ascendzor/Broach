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
    class RenderComponent : GameComponent
    {

        private VertexPositionNormalTexture[] vertices;
        private Texture2D texture;

        private Camera camera;

        private Matrix translation;

        public Matrix TranslationMatrix
        {
            get { return translation; }
            set { translation = value; }
        }
        
        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }
        
        public VertexPositionNormalTexture[] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        
        public RenderComponent()
        {
            translation = Matrix.Identity;
            Game1.Systems["Render"].Components.Add(this);
        }
    }
}
