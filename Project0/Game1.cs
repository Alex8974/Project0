﻿using Microsoft.Xna.Framework;
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

        private SpriteFont font;
        private String instructions = "To exit the game press the ESC key on the keyboard";

        private KeyboardState currentKeyboardState;
        private KeyboardState priorKeyboardState;

        private Random rand;

        private PenguinSprite penguin;
        private Fish[] fish;

        

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
            

            font = Content.Load<SpriteFont>("Timer");
            

            #region Penuin Setup

            penguin = new PenguinSprite();
            penguin.PenguinTexture = Content.Load<Texture2D>("Penguin2");

            #endregion

            #region Setting up fish
            fish = new Fish[2];
            fish[0] = new Fish();
            fish[1] = new Fish();
            fish[0].FishTexture = Content.Load<Texture2D>("Fish");
            fish[1].FishTexture = Content.Load<Texture2D>("FishPink20px");
            foreach (var f in fish) f.Initlize();

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

            #region Move Fish

            // TODO: Add your update logic here
            foreach (var f in fish) f.Update(gameTime);

            #endregion

            

            #region Move Penguin

            penguin.Update(gameTime, currentKeyboardState);

            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();       
            penguin.Draw(gameTime, _spriteBatch);
            foreach (Fish f in fish) f.Draw(gameTime, _spriteBatch);
            //_spriteBatch.DrawString(font, "" + gameTime.TotalGameTime.TotalSeconds.ToString(), new Vector2(700, 0), Color.Black);
            _spriteBatch.DrawString(font, GraphicsDevice.Viewport.Width + " "+ GraphicsDevice.Viewport.Height, new Vector2(700, 0), Color.Black);
            _spriteBatch.DrawString(font, instructions, new Vector2(50, 50), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}