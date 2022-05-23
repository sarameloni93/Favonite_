using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Favonite.Controls;
using System.ComponentModel;
using Favonite.Core;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Favonite.States
{
    class GameOverState : State
    {

        private List<Component> _components;
        private Texture2D menuBackgroundTexture, icon;
        private SpriteBatch _spriteBatch;

        public GameOverState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice, content, spriteBatch)
        {
            _spriteBatch = spriteBatch;

            var buttonTexture = _content.Load<Texture2D>("startGame");

            var newGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 600),

            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 950),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                quitGameButton
            };

        }

        public override void Initialize()
        {
            
                var buttonTexture = _content.Load<Texture2D>("startGame");
                menuBackgroundTexture = _content.Load<Texture2D>("Main Menu Background");
                icon = _content.Load<Texture2D>("FavoniteIcon");

        }

        public override void LoadContent()
        {
            
        }
        public override void UnloadContent()
        {

        }


        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
        public override void PostUpdate(GameTime gameTime)
        {
            
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            

            //draw each button component
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();

        }


        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, _spriteBatch));
        }
    }
}
