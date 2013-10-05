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
    /// <summary>
    /// RenderSystem is for 3d drawing
    /// </summary>
    class RenderSystem: GameSystem
    {
        private BasicEffect material;
        private Game1 game;

        public BasicEffect Material
        {
            get { return material; }
            set { material = value; }
        }

        public RenderSystem(Game1 g)
        {
            game = g;
            material = new BasicEffect(g.GraphicsDevice);
            material.EnableDefaultLighting();
            material.TextureEnabled = true;
        }
        public override void Update(GameTime gameTime)
        {
            game.GraphicsDevice.BlendState = BlendState.Opaque;
            game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            game.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;


            foreach (RenderComponent item in Components)
            {
                // set render state items

                material.Texture = item.Texture;
                material.World = Matrix.Identity;
                material.View = item.Camera.View;
                material.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, game.GraphicsDevice.Viewport.AspectRatio, 1, 1000);

                foreach (EffectPass pass in material.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, item.Vertices, 0, item.Vertices.Length / 3);
                }
            }
        }
    }
}
