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

namespace GameTestyBit2D
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> gameObjects = new List<GameObject>();
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
            
        }


        Texture2D arrow;
        Texture2D grass;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            arrow = Content.Load<Texture2D>("arrow");
            grass = Content.Load<Texture2D>("grass");

            Vector2 location = new Vector2(GraphicsDevice.Viewport.Width / 2,GraphicsDevice.Viewport.Height / 2);
            //GameObject Arrow = new GameObject(arrow, location, 0);
            //Arrow.velocity = new Vector2(50, 0);
            //gameObjects.Add(Arrow);

            player = new Player(location, arrow, 300, 150);

            for (int i = 0; i < 20; i++)
            {
                GameObject game = new GameObject(grass, new Vector2(0 + i * grass.Width / 2, 800), 0);
                gameObjects.Add(game);
            }
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

     
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            foreach (GameObject gameobj in gameObjects)
            {
                gameobj.velocity = Vector2.Zero;
                gameobj.velocity = -1 * player.velocity;
                
                gameobj.UpdateVelocity(gameTime);
            }


            KeyboardState keyboardState = Keyboard.GetState();
            
            player.PlayerUpdate(keyboardState, gameTime);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            player.Draw(spriteBatch);

            foreach (GameObject gameobj in gameObjects)
            {
                gameobj.Draw(spriteBatch);
            }
            

            spriteBatch.End();
            base.Draw(gameTime);
        }

      
    }
}
