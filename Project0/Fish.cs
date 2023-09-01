using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
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

        public void Initlize()
        {
            rand = new Random();

            FishPosition = new Vector2(
                (float)rand.NextDouble(),
                460
                );
            FishDirection = new Vector2(
                (float)rand.NextDouble(),
                (float)rand.NextDouble()
                );
        }

        public void Update(GameTime gameTime)
        {
            if (((int)gameTime.TotalGameTime.TotalSeconds) % 10 == 0 && (int)gameTime.TotalGameTime.TotalSeconds != 0)
            {
                FishDirection = new Vector2(
                    (float)(rand.NextDouble() * 100 * gameTime.ElapsedGameTime.TotalSeconds),
                    (float)(rand.NextDouble() * 100 * gameTime.ElapsedGameTime.TotalSeconds)
                    );
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
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(FishDirection.X < 0)
            {
                spriteBatch.Draw(FishTexture, FishPosition,null, Color.White, 0, new Vector2(0,0), 1f, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(FishTexture, FishPosition, Color.White);
            }
        }


    }
}
