using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    public class BirdSprite
    {
        private int frame = 1;
        private double animationTimer;
        public Vector2 BirdPosition = new Vector2(100,100);
        public Texture2D BirdTexture;
        
        public void LoadContent(ContentManager content)
        {
            //BirdTexture = content.Load<Texture2D>("BirdSprite");
        }


        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            

            var source = new Rectangle(frame * 16, 16, 16, 16);
            spriteBatch.Draw(BirdTexture, BirdPosition, source, Color.White);
        }

    }
}
