using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollisionExample.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX;
//using SharpDX.Direct2D1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Project0
{
    public class Fish
    {
        public Vector2 FishPosition;
        public Vector2 FishDirection;
        public Texture2D FishTexture;
        private Random rand;
        private int gameWindowHeight = 480;
        private int gameWindowWidth = 800;
        private int directionx = 1;
        private int frame;
        private double animationTimer;
        private BoundingRectangle bounds;
        public BoundingRectangle Bounds => bounds;
        public bool Collected = false;


        public Fish(ContentManager content)
        {
            FishTexture = content.Load<Texture2D>("fishSpriteSheet");
            rand = new Random();
            FishPosition = new Vector2(300, 420);
            frame = rand.Next(13);
            FishDirection = new Vector2(1, 1);
            bounds = new BoundingRectangle(FishPosition, 32, 32);
        }

        public void Initlize()
        {
            rand = new Random();

            FishPosition = new Vector2(
                (float)rand.NextDouble(),
                460
                );
            FishDirection = new Vector2(-1, 1);
        }

        public void Update(GameTime gameTime, Vector2 penguinpos)
        {
            
            if (((int)gameTime.TotalGameTime.TotalMilliseconds) % 100 == 0 && (int)gameTime.TotalGameTime.TotalMilliseconds != 0)
            {
                

                if (Math.Abs(penguinpos.X - FishPosition.X) < 150 && rand.Next(10) > 7)
                {                   
                    if (penguinpos.X < FishPosition.X) directionx = 1;
                    else directionx = -1;
                }
                if(rand.Next(10) > 8)
                {
                    int fishDirY = rand.Next(0, 3);
                    if (fishDirY == 1) FishDirection = new Vector2(directionx, -1);                    
                    else FishDirection = new Vector2(directionx, 1);
                }
                                
            }

            if (FishPosition.X < 0 ||
               FishPosition.X > gameWindowWidth - 20) //to keep the ball totally on the scren you must account for the width of the ball
            {
                FishDirection.X *= -1;
            }

            if (FishPosition.Y < 402 ||
               FishPosition.Y > gameWindowHeight - 20)
            {
                FishDirection.Y *= -1;
            }
            FishDirection.Normalize();
            FishPosition += FishDirection;

            bounds.X = FishPosition.X;
            bounds.Y = FishPosition.Y;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Collected) return;
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.15)
            {
                frame += 1;
                if (frame > 11)
                {
                    frame = 1;
                }
                animationTimer = 0;
            }

            var source = new Rectangle(frame * 16, 0, 16, 16);
            //spriteBatch.Draw(FishTexture, FishPosition, source, Color.White, 0, new Vector2(64, 64), 2f, SpriteEffects.FlipHorizontally, 0);


            if (FishDirection.X < 0)
            {
                spriteBatch.Draw(FishTexture, FishPosition, source, Color.White, 0, new Vector2(0,0), 2f, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(FishTexture, FishPosition, source, Color.White, 0, new Vector2(0,0), 2f, SpriteEffects.None, 0);
            }
        }


    }
}
