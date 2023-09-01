using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;
using System;
using System.Drawing.Printing;
using System.Web;

namespace Project0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;
        private String title = "Penguin Paradise";

        private KeyboardState currentKeyboardState;
        private KeyboardState priorKeyboardState;

        private Random rand;

        private PenguinSprite penguin;
        private Fish[] fish;
        private BirdSprite bird;

        private Texture2D background;

        

        

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
            

            font = Content.Load<SpriteFont>("bangers");
            

            #region Penuin Setup

            penguin = new PenguinSprite();
            penguin.Initilize();
            #endregion

            #region Setting up fish
            fish = new Fish[2];
            fish[0] = new Fish();
            fish[1] = new Fish();

            foreach (var f in fish) f.Initlize();

            #endregion

            bird = new BirdSprite();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            penguin.loadContnet(Content);
            fish[0].FishTexture = Content.Load<Texture2D>("Fish");
            fish[1].FishTexture = Content.Load<Texture2D>("FishPink20px");
            bird.LoadContent(Content);
            background = Content.Load<Texture2D>("Backgound3");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Move Fish

            // TODO: Add your update logic here
            foreach (var f in fish) f.Update(gameTime);

            #endregion            

            #region Move Penguin

            penguin.Update(gameTime, currentKeyboardState);

            #endregion

            #region Updates the bird
            bird.Update(gameTime);
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            penguin.Draw(gameTime, _spriteBatch);
            foreach (Fish f in fish) f.Draw(gameTime, _spriteBatch);
            bird.Draw(gameTime, _spriteBatch);
            //_spriteBatch.DrawString(font, "" + gameTime.TotalGameTime.TotalSeconds.ToString(), new Vector2(700, 0), Color.Black);
            //_spriteBatch.DrawString(font, GraphicsDevice.Viewport.Width + " "+ GraphicsDevice.Viewport.Height, new Vector2(700, 0), Color.Black);
            _spriteBatch.DrawString(font, title, new Vector2(175, 100), Color.Navy);
            _spriteBatch.DrawString(font, "Press 'ESC' to exit the game", new Vector2(10, 10), Color.Black, 0, new Vector2(0,0), 0.2f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}