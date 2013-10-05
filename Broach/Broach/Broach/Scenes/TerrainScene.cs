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
        VertexPositionNormalTexture[] oceanVerts;

        Texture2D groundcover;
        Texture2D oceantex;

        float[,] heights;
        float oceanheight = 14f;

        Camera cam = new Camera()
        {
            Position = new Vector3(100,0,100)
        };


        public TerrainScene(ContentManager Content, Game1 game)
        {
            game.IsMouseVisible = false;

            // setting up verticies and normals for
            oceantex = Content.Load<Texture2D>("oceantex");
            oceanVerts = new VertexPositionNormalTexture[4 * 2 * 3];

            oceanVerts[0].Position = new Vector3(0, oceanheight, 255);
            oceanVerts[0].Normal = new Vector3(0, 1, 0);
            oceanVerts[0].TextureCoordinate = new Vector2(0, 0);
            oceanVerts[1].Position = new Vector3(0, oceanheight, 0);
            oceanVerts[1].Normal = new Vector3(0, 1, 0);
            oceanVerts[1].TextureCoordinate = new Vector2(0, 1);
            oceanVerts[2].Position = new Vector3(255, oceanheight, 0);
            oceanVerts[2].Normal = new Vector3(0, 1, 0);
            oceanVerts[2].TextureCoordinate = new Vector2(1, 1);

            oceanVerts[3].Position = new Vector3(0, oceanheight, 255);
            oceanVerts[3].Normal = new Vector3(0, 1, 0);
            oceanVerts[3].TextureCoordinate = new Vector2(0, 0);
            oceanVerts[4].Position = new Vector3(255, oceanheight, 0);
            oceanVerts[4].Normal = new Vector3(0, 1, 0);
            oceanVerts[4].TextureCoordinate = new Vector2(1, 1);
            oceanVerts[5].Position = new Vector3(255, oceanheight, 255);
            oceanVerts[5].Normal = new Vector3(0, 1, 0);
            oceanVerts[5].TextureCoordinate = new Vector2(1, 0);


            // setting up verticies and normals for terrain
            vertices = new VertexPositionNormalTexture[255 * 255 * 2 * 3];

            groundcover = Content.Load<Texture2D>("grasstexture");
            #region get height data
            Texture2D heighttexture = Content.Load<Texture2D>("gradmap");
            Color[] heightdata = new Color[256 * 256];
            heighttexture.GetData<Color>(heightdata);

            heights = new float[256, 256];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    heights[r, c] = (heightdata[r * 256 + c].G ) / 4.0f;
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

            RenderComponent renderOcean = new RenderComponent()
            {
                Camera = cam,
                Vertices = oceanVerts,
                Texture = oceantex
            };
            // render terrain, see RenderSystem for the implementation and drawuserprimitives call
            RenderComponent terrain = new RenderComponent()
            {
                Camera = cam,
                Vertices = vertices,
                Texture = groundcover,
            };


            

            // render 2d textures
            SpriteComponent instructionsLabel = new SpriteComponent()
            {
                Draw = (SpriteBatch b) => {
                    b.DrawString(Content.Load<SpriteFont>("SpriteFont1"), cam.ToString(), new Vector2(0, 0), Color.Bisque);
                },
            };
            
            // event listener for escape key
            OnKeyUpComponent returnToMenu = new OnKeyUpComponent()
            {
                ActivationKey = Keys.Escape,
                OnClick = () =>
                {
                    game.Exit();
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

                    Vector3 forward = Vector3.Transform(new Vector3(0,0,-1), Matrix.CreateRotationY(cam.Direction.Bearing));
                    Vector3 right = Vector3.Cross(forward, Vector3.Up);

                    Vector3 moveVector = new Vector3(0,0,0);

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
