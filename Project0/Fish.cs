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
        private int gameWindowHeight = 450;
        private int gameWindowWidth = 800;

        public void Initlize()
        {
            rand = new Random();

            FishPosition = new Vector2(
                800 / 2 + 100,
                450 / 2 + 50
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

            if (FishPosition.Y < 0 ||
               FishPosition.Y > gameWindowHeight - 20)
            {
                FishDirection.Y *= -1;
            }
            FishDirection.Normalize();
            FishPosition += FishDirection;
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FishTexture, FishPosition, Color.White);
        }


    }
}
