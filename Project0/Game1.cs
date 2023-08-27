using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing.Printing;

namespace Project0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _PenguinPosition;
        private Texture2D _PenguinTexture;

        private Vector2 fishPostition;
        private Texture2D fishTexture;
        private Vector2 fishDirection;

        private SpriteFont font;

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
            fishPostition = new Vector2(
                GraphicsDevice.Viewport.Width / 2 + 100,
                GraphicsDevice.Viewport.Height / 2 + 50
                );

            _PenguinTexture = Content.Load<Texture2D>("Penguin2");
            fishTexture = Content.Load<Texture2D>("Fish");
            font = Content.Load<SpriteFont>("Timer");

            fishDirection = new Vector2(
                (float)rand.NextDouble(),
                (float)rand.NextDouble()
                );

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

            // TODO: Add your update logic here
            if(((int)gameTime.TotalGameTime.TotalSeconds) % 10 == 0 && (int)gameTime.TotalGameTime.TotalSeconds != 0)
            {
                fishDirection = new Vector2(
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds,
                    (float)rand.NextDouble() * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds
                    );
            }

            

            fishPostition += fishDirection;
            
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
            _spriteBatch.Draw(fishTexture, fishPostition, Color.White);
            _spriteBatch.DrawString(font, "" + gameTime.TotalGameTime.TotalSeconds.ToString(), new Vector2(700, 0), Color.Black);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}