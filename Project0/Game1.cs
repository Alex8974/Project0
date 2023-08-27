using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(_PenguinTexture, _PenguinPosition, Color.White);
            _spriteBatch.Draw(fishTexture, fishPostition, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}