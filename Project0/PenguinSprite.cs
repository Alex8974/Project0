using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;

namespace Project0
{
    public class PenguinSprite
    {
        public Vector2 PenguinPosition;
        public Texture2D PenguinTexture;        


        public void Update(GameTime gameTime, KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
               currentKeyboardState.IsKeyDown(Keys.A))
            {
                PenguinPosition += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
               currentKeyboardState.IsKeyDown(Keys.D))
            {
                PenguinPosition += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up) ||
               currentKeyboardState.IsKeyDown(Keys.W))
            {
                PenguinPosition += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down) ||
               currentKeyboardState.IsKeyDown(Keys.S))
            {
                PenguinPosition += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PenguinTexture, PenguinPosition, Color.White);
        }
    }
}
