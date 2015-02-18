using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace GameTestyBit2D
{
    class Player
    {
    
        public float speed;
        public float jumpHeight;
        public int heatlh;
        public int lives;

        public Vector2 position;
        public Vector2 velocity;
        public float rotation;
        Texture2D texture;

        public Player(Vector2 position, Texture2D texture, float speed, int health)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.heatlh = health;
        }
        public void PlayerUpdate(KeyboardState keyboardState, GameTime gameTime)
        {
            if (keyboardState.IsKeyDown(Keys.D))
            {
                velocity = new Vector2(0, velocity.Y);
                velocity += new Vector2(1, 0) * speed;
            }
    
            if (keyboardState.IsKeyDown(Keys.A))
            {
                velocity = new Vector2(0, velocity.Y);
                velocity += new Vector2(-1, 0) * speed;
            }

            if (keyboardState.GetPressedKeys().Length == 0)
            {
                velocity = new Vector2(0, velocity.Y);
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height);

            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 1);
        }
    }
}
