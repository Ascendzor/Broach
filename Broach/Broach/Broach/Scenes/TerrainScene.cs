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
    class TerrainScene : Scene
    {

        const int rows = 255, cols = 255;
        VertexPositionNormalTexture[] vertices;
        BasicEffect material;
        Texture2D groundcover;
        float[,] heights;
        Camera cam = new Camera()
        {
            Position = new Vector3(100,0,100)
        };
        

        public TerrainScene(ContentManager Content, Game1 game)
        {
            game.IsMouseVisible = false;

            vertices = new VertexPositionNormalTexture[255 * 255 * 2 * 3];
            groundcover = Content.Load<Texture2D>("rocktex");
            material = new BasicEffect(game.GraphicsDevice);
            material.EnableDefaultLighting();
            material.TextureEnabled = true;
            material.Texture = groundcover;

            #region get height data
            Texture2D heighttexture = Content.Load<Texture2D>("hmap");
            Color[] heightdata = new Color[256 * 256];
            heighttexture.GetData<Color>(heightdata);

            heights = new float[256, 256];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    heights[r, c] = (heightdata[r * 256 + c].G - 128) / 4.0f;
                }
            }
            #endregion

            #region make vertices
            int v = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    vertices[v + 0].Position = new Vector3(c, heights[c, r], r);
                    vertices[v + 0].Normal = new Vector3(0, 1, 0);
                    vertices[v + 0].TextureCoordinate = new Vector2((c + 0) / 32.0f,
                                                                    (r + 0) / 32.0f);

                    vertices[v + 1].Position = new Vector3(c + 1, heights[c + 1, r], r);
                    vertices[v + 1].Normal = new Vector3(0, 1, 0);
                    vertices[v + 1].TextureCoordinate = new Vector2((c + 1) / 32.0f,
                                                                    (r + 0) / 32.0f);
                    vertices[v + 2].Position = new Vector3(c, heights[c, r + 1], r + 1);
                    vertices[v + 2].Normal = new Vector3(0, 1, 0);
                    vertices[v + 2].TextureCoordinate = new Vector2((c + 0) / 32.0f,
                                                                    (r + 1) / 32.0f);

                    vertices[v + 3].Position = new Vector3(c + 1, heights[c + 1, r], r);
                    vertices[v + 3].Normal = new Vector3(0, 1, 0);
                    vertices[v + 3].TextureCoordinate = new Vector2((c + 1) / 32.0f,
                                                                    (r + 0) / 32.0f);

                    vertices[v + 4].Position = new Vector3(c + 1, heights[c + 1, r + 1], r + 1);
                    vertices[v + 4].Normal = new Vector3(0, 1, 0);
                    vertices[v + 4].TextureCoordinate = new Vector2((c + 1) / 32.0f,
                                                                    (r + 1) / 32.0f);

                    vertices[v + 5].Position = new Vector3(c, heights[c, r + 1], r + 1);
                    vertices[v + 5].Normal = new Vector3(0, 1, 0);
                    vertices[v + 5].TextureCoordinate = new Vector2((c + 0) / 32.0f,
                                                                    (r + 1) / 32.0f);
                    v = v + 6;
                }
            }
            #endregion

            #region fix normals
            for (v = 0; v < vertices.Length; v += 3)
            {
                Vector3 normal
                    = Vector3.Cross(vertices[v + 2].Position - vertices[v].Position,
                                    vertices[v + 1].Position - vertices[v].Position);
                normal.Normalize();
                vertices[v].Normal = normal;
                vertices[v + 1].Normal = normal;
                vertices[v + 2].Normal = normal;
            }
            #endregion

            #region average normals (smooth)
            // Average normals
            v = 255 * 6;
            for (int r = 1; r < rows; r++)
            {
                v += 6;
                for (int c = 1; c < cols; c++)
                {
                    Vector3 normal = vertices[v].Normal
                                   + vertices[v - 6 + 1].Normal
                                   + vertices[v - 6 + 3].Normal
                                   + vertices[v - 255 * 6 + 2].Normal
                                   + vertices[v - 255 * 6 + 5].Normal
                                   + vertices[v - 255 * 6 - 6 + 4].Normal;
                    normal.Normalize();
                    vertices[v].Normal = normal;
                    vertices[v - 6 + 1].Normal = normal;
                    vertices[v - 6 + 3].Normal = normal;
                    vertices[v - 255 * 6 + 2].Normal = normal;
                    vertices[v - 255 * 6 + 5].Normal = normal;
                    vertices[v - 255 * 6 - 6 + 4].Normal = normal;
                    v += 6;
                }
            }
            #endregion


            // render terrain
            ScriptComponent  renderTerrain = new ScriptComponent()
            {
                UpdateAction = (GameTime dt, object data) =>
                {
                    
                    game.GraphicsDevice.BlendState = BlendState.Opaque;
                    game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                    material.World = Matrix.Identity;
                    material.View = cam.View;
                    material.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.PiOver2, game.GraphicsDevice.Viewport.AspectRatio, 1, 1000);

                    foreach (EffectPass pass in material.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                            vertices, 0, vertices.Length / 3);
                    }
                },
            };

            // render 2d textures
            RenderComponent instructionsLabel = new RenderComponent()
            {
                Draw = (SpriteBatch b) => {
                    b.DrawString(Content.Load<SpriteFont>("SpriteFont1"), "Press esc to return to main menu\n" + cam.ToString(), new Vector2(0, 0), Color.Bisque);
                },
            };

            
            // event listener for escape key
            OnKeyUpComponent returnToMenu = new OnKeyUpComponent()
            {
                ActivationKey = Keys.Escape,
                OnClick = () =>
                {
                    Game1.SceneController.Handle(SceneFactory.getMainMenu(Content, game));
                }
            };

            // Setup camera move inputs
            MouseState referencePosition = Mouse.GetState();
            float speed = 0.01f;
            float moveRate = 0.5f;

            ScriptComponent updateCamera = new ScriptComponent()
            {
                UpdateAction = (GameTime dt, object d) =>
                {
                    MouseState currentMouseState = Mouse.GetState();
                    if (referencePosition != currentMouseState)
                    {
                        float dX = referencePosition.X - currentMouseState.X;
                        float dY = referencePosition.Y - currentMouseState.Y;

                        cam.Direction.Elevation += speed * dY;
                        cam.Direction.Bearing += speed * dX;
                        Mouse.SetPosition(referencePosition.X, referencePosition.Y);

                    }

                    Vector3 forward = Vector3.Transform(new Vector3(0,0,-1), Matrix.CreateRotationX(cam.Direction.Elevation) * Matrix.CreateRotationY(cam.Direction.Bearing));
                    Vector3 right = Vector3.Cross(forward, Vector3.Up);
                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                        cam.Position += forward * moveRate;
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                        cam.Position -= right * moveRate;
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        cam.Position += right * moveRate;
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                        cam.Position -= forward * moveRate;

                    cam.Position = new Vector3(cam.Position.X, heights[(int)cam.Position.X, (int)cam.Position.Z] + 5, cam.Position.Z);
                }
            };

            
        }
    }
}
