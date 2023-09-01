using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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
        private int direction = 1;
        public Vector2 BirdPosition = new Vector2(300,300);
        public Texture2D BirdTexture;
        
        public void LoadContent(ContentManager content)
        {
            BirdTexture = content.Load<Texture2D>("BirdSprite");
        }


        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.15)
            {
                frame += 1;
                if (frame > 7)
                {
                    frame = 1;
                }
                animationTimer = 0;
            }

            var source = new Rectangle(frame * 16, 16, 16, 16);
            spriteBatch.Draw(BirdTexture, BirdPosition, source, Color.White, 0, new Vector2(64, 64), 2f, SpriteEffects.None, 0);
        }

    }
}
