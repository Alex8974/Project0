using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing.Printing;
using System.Web;

namespace Project0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _PenguinPosition;
        private Texture2D _PenguinTexture;

        private Vector2 fishPostition1;
        private Texture2D fishTexture1;
        private Vector2 fishDirection1;

        private Vector2 fishPostition2;
        private Texture2D fishTexture2;
        private Vector2 fishDirection2;

        private SpriteFont font;
        private String instructions = "To exit the game press the ESC key on the keyboard";

        private KeyboardState currentKeyboardState;
        private KeyboardState priorKeyboardState;

        private Random rand;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Pengin Paradise";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rand = new Random();
            _PenguinPosition = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2
                );
            

            _PenguinTexture = Content.Load<Texture2D>("Penguin2");
            fishTexture1 = Content.Load<Texture2D>("Fish");
            fishTexture2 = Content.Load<Texture2D>("FishPink20px");
            font = Content.Load<SpriteFont>("Timer");

            #region Setting up fish movement

            fishPostition1 = new Vector2(
                GraphicsDevice.Viewport.Width / 2 + 100,
                GraphicsDevice.Viewport.Height / 2 + 50
                );
            fishDirection1 = new Vector2(
                (float)rand.NextDouble(),
                (float)rand.NextDouble()
                );

            fishDirection2 = new Vector2(
                (float)rand.NextDouble(),
                (float)rand.NextDouble()
                );
            fishPostition2 = new Vector2(
                GraphicsDevice.Viewport.Width / 2 - 100,
                GraphicsDevice.Viewport.Height / 2 - 50
                );

            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Move Fish Yellow

            // TODO: Add your update logic here
            if (((int)gameTime.TotalGameTime.TotalSeconds) % 10 == 0 && (int)gameTime.TotalGameTime.TotalSeconds != 0)
            {
                fishDirection1 = new Vector2(
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds,
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds
                    );
            }

            if (fishPostition1.X < GraphicsDevice.Viewport.X ||
               fishPostition1.X > GraphicsDevice.Viewport.Width - 20) //to keep the ball totally on the scren you must account for the width of the ball
            {
                fishDirection1.X *= -1;
            }

            if (fishPostition1.Y < GraphicsDevice.Viewport.Y ||
               fishPostition1.Y > GraphicsDevice.Viewport.Height - 20)
            {
                fishDirection1.Y *= -1;
            }

            fishPostition1 += fishDirection1;

            #endregion

            #region Move Fish Purple

            // TODO: Add your update logic here
            if (((int)gameTime.TotalGameTime.TotalSeconds) % 10 == 0 && (int)gameTime.TotalGameTime.TotalSeconds != 0)
            {
                fishDirection2 = new Vector2(
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds,
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds
                    );
            }

            if (fishPostition2.X < GraphicsDevice.Viewport.X ||
               fishPostition2.X > GraphicsDevice.Viewport.Width - 20) //to keep the ball totally on the scren you must account for the width of the ball
            {
                fishDirection2.X *= -1;
            }

            if (fishPostition2.Y < GraphicsDevice.Viewport.Y ||
               fishPostition2.Y > GraphicsDevice.Viewport.Height - 20)
            {
                fishDirection2.Y *= -1;
            }

            fishPostition2 += fishDirection2;

            #endregion

            #region Move Penguin
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
               currentKeyboardState.IsKeyDown(Keys.A))
            {
                _PenguinPosition += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
               currentKeyboardState.IsKeyDown(Keys.D))
            {
                _PenguinPosition += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up) ||
               currentKeyboardState.IsKeyDown(Keys.W))
            {
                _PenguinPosition += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down) ||
               currentKeyboardState.IsKeyDown(Keys.S))
            {
                _PenguinPosition += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(_PenguinTexture, _PenguinPosition, Color.White);
            _spriteBatch.Draw(fishTexture1, fishPostition1, Color.White);
            _spriteBatch.Draw(fishTexture2, fishPostition2, Color.White);
            _spriteBatch.DrawString(font, "" + gameTime.TotalGameTime.TotalSeconds.ToString(), new Vector2(700, 0), Color.Black);
            _spriteBatch.DrawString(font, instructions, new Vector2(50, 50), Color.Black);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}