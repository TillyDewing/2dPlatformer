using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameTestyBit2D
{
    public class GameObject
    {
        public Vector2 position;
        public Vector2 velocity;
        public float rotation;
        Texture2D texture;
        

       
        
        public GameObject(Texture2D texture, Vector2 position, float rotation)
        {
            this.position = position;
            this.texture = texture;
            this.rotation = rotation;
        }
        public GameObject(Texture2D texture, Vector2 position, float rotation, Vector2 velocity)
        {
            this.position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.rotation = rotation;
        }
        

         public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height);
            
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 1);
        }

         public void UpdateVelocity(GameTime gameTime)
         {
             position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
         }
    }
}
