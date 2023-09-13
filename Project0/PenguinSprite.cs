using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollisionExample.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;

namespace Project0
{
    enum Action
    {
        standing,
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
        private float magicNumber = 370;
        private int direction = 1;
        private float size = 0.5f;
        private float pheight = 30;
        private float growthrate = 0.01f;


        private BoundingRectangle bounds;
        public BoundingRectangle Bounds => bounds;
        public Color color = Color.White;
        public int FishCollected;

        /// <summary>
        /// initilizes the penguins pposition
        /// </summary>
        public void Initilize()
        {
            this.bounds = new BoundingRectangle(PenguinPosition, 32, 30);
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
                action = Action.standing;
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
                action = Action.standing;
            }
        }

        /// <summary>
        /// updates the penguin 
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="currentKeyboardState">the current keyboard states</param>
        public void Update(GameTime gameTime, KeyboardState currentKeyboardState)
        {

            #region left right movement
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
            #endregion

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
                if(dive == 0) PenguinPosition.Y = magicNumber + pheight;
                Dive(gameTime);
            }

            // checks to make sure you can jump or dive
            if (action != Action.jumping && action != Action.diving)
            {
                if (PenguinPosition.Y < magicNumber -30+ pheight) PenguinPosition.Y += 1;
                else PenguinPosition.Y -= 1;           
            }
            bounds.X = PenguinPosition.X;
            bounds.Y = PenguinPosition.Y;
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            
            //for(int i = 0; i < FishCollected; i++)
            //{
            //    size += growthrate;

            //}
            //FishCollected = 0;
            

            if (direction == 1 && action != Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, color, 0, new Vector2(0, 0), size, SpriteEffects.None, 0);
            if(direction == 2 && action != Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, color, 0, new Vector2(0, 0), size, SpriteEffects.FlipHorizontally, 0);
            if(action == Action.diving) spriteBatch.Draw(PenguinTexture, PenguinPosition, null, color, 0, new Vector2(0, 0), size, SpriteEffects.FlipVertically, 0);
        }
    }
}
