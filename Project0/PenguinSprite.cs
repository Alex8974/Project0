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
    enum Action
    {
        staning,
        moving,
        jumping,
        diving
    };

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
        private Action action;
        private int jumps = 0;
        private int dive = 0;
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
                action = Action.staning;
            }
        }

        private void Dive(GameTime gameTime)
        {
            PenguinPosition += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (dive < 10)
            {
                dive++;
            }
            else
            {
                dive = 0;
                action = Action.staning;
            }
        }

        /// <summary>
        /// updates the penguin 
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="currentKeyboardState">the current keyboard states</param>
        public void Update(GameTime gameTime, KeyboardState currentKeyboardState)
        {
            //moves left
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
               currentKeyboardState.IsKeyDown(Keys.A))
            {
                PenguinPosition += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                direction = 2;
                
            }

            //moves right
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
               currentKeyboardState.IsKeyDown(Keys.D))
            {
                PenguinPosition += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                direction = 1;
                
            }

            #region Jump Controlls

            // sets action to jumping
            if ( PenguinPosition.Y >= magicNumber &&
               (currentKeyboardState.IsKeyDown(Keys.Up) ||
               currentKeyboardState.IsKeyDown(Keys.W) || 
               currentKeyboardState.IsKeyDown(Keys.Space)))
            {
                action = Action.jumping;
            }

            // triggers the jump action
            if(action == Action.jumping)
            {
                jump(gameTime);
            }

            #endregion

            if ( 1 >= Math.Abs(magicNumber - PenguinPosition.Y) &&
                currentKeyboardState.IsKeyDown(Keys.Down) ||
               currentKeyboardState.IsKeyDown(Keys.S))
            {
                action = Action.diving;
            }

            if (action == Action.diving)
            {
                if(dive == 0) PenguinPosition.Y = magicNumber+32;
                Dive(gameTime);
            }

            // checks to make sure you can jump or dive
            if (action != Action.jumping && action != Action.diving)
            {
                if (PenguinPosition.Y < magicNumber) PenguinPosition.Y += 1;
                else PenguinPosition.Y -= 1;           
            }
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            if(direction == 1 && action != Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            if(direction == 2 && action != Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.FlipHorizontally, 0);
            if(action == Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.FlipVertically, 0);
        }
    }
}
