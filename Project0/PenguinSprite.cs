using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;

namespace Project0
{
    /// <summary>
    /// class for the penguin sprite
    /// </summary>
    public class PenguinSprite
    {
        /// <summary>
        /// the penguins position
        /// </summary>
        public Vector2 PenguinPosition;
        
        private Texture2D PenguinTexture;
        private bool jumpping = false;
        private int jumps = 0;
        private int magicNumber = 370;
        private int direction = 1;

        /// <summary>
        /// initilizes the penguins pposition
        /// </summary>
        public void Initilize()
        {
            PenguinPosition = new Vector2(300, magicNumber);
        }

        /// <summary>
        /// loads the content of the penguin 
        /// </summary>
        /// <param name="content">the content manager being loaded in</param>
        public void loadContnet(ContentManager content)
        {
            PenguinTexture = content.Load<Texture2D>("Penguin3Good");
        }

        /// <summary>
        /// makes the penguin jump 
        /// </summary>
        /// <param name="gameTime">the time of the game</param>
        private void jump(GameTime gameTime)
        {
            PenguinPosition += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if(jumps < 10)
            {
                jumps++;
            }
            else
            {
                jumps = 0;
                jumpping = false;
            }
        }

        /// <summary>
        /// updates the penguin 
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="currentKeyboardState">the current keyboard states</param>
        public void Update(GameTime gameTime, KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
               currentKeyboardState.IsKeyDown(Keys.A))
            {
                PenguinPosition += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                direction = 2;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
               currentKeyboardState.IsKeyDown(Keys.D))
            {
                PenguinPosition += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                direction = 1;
            }
            if ( PenguinPosition.Y >= magicNumber &&
               (currentKeyboardState.IsKeyDown(Keys.Up) ||
               currentKeyboardState.IsKeyDown(Keys.W) || 
               currentKeyboardState.IsKeyDown(Keys.Space)))
            {
                jumpping = true;
            }

            if(jumpping == true)
            {
                jump(gameTime);
            }
            //if (currentKeyboardState.IsKeyDown(Keys.Down) ||
            //   currentKeyboardState.IsKeyDown(Keys.S))
            //{
            //    PenguinPosition += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            //}
            if(PenguinPosition.Y < magicNumber && jumpping == false)
            {
                PenguinPosition.Y += 1;
            }
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            if(direction == 1) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            if(direction == 2) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
