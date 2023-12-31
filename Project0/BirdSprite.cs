﻿using Microsoft.Xna.Framework;
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
        public Vector2 BirdPosition;
        public Texture2D BirdTexture;
        
        public BirdSprite(ContentManager content, int posY)
        {
            BirdTexture = content.Load<Texture2D>("BirdSprite");
            BirdPosition = new Vector2(-50, posY);
        }

        public void LoadContent(ContentManager content)
        {
            BirdTexture = content.Load<Texture2D>("BirdSprite");
        }


        public void Update(GameTime gameTime)
        {
            BirdPosition.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(BirdPosition.X > 950)
            {
                BirdPosition.X = -50;
            }
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
            spriteBatch.Draw(BirdTexture, BirdPosition, source, Color.White, 0, new Vector2(64, 64), 2f, SpriteEffects.FlipHorizontally, 0);
        }

    }
}
