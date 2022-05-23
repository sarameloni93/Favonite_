using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite
{
    class Enemy
    {
        #region Declarations
        public Animation enemyAnimation;
        public Vector2 position, velocity;
        public bool active;
        public int health;
        public int Damage;
        public int value;
        float enemyMoveSpeed;

        Random random = new Random();
        int randX, randY;

        public int Width
        {
            get { return enemyAnimation.frameWidth; }
        }

        public int Height
        {
            get { return enemyAnimation.frameHeight; }
        }

        #endregion
        public void Initialize(Animation animation, Vector2 position)
        {
           enemyAnimation = animation;
            this.position = position;
            active = true;
            health = 10;
            Damage = 10;
            enemyMoveSpeed = 2f;
            value = 100;

            randX = random.Next(-4, 4);
            randY = random.Next(-4, 4);

            velocity = new Vector2(randX, randY);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            enemyAnimation.position = position;

            enemyAnimation.Update(gameTime);

            if (position.X < -Width || health <= 0)
            {
                active = false;
            }
            if(position.Y <= 0 || position.Y > Globals.screenHeight - enemyAnimation.frameHeight)
            {
                velocity.Y = -velocity.Y;
            }
            if (position.X <0  - enemyAnimation.frameWidth)
            {
                active = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyAnimation.Draw(spriteBatch);
        }
    }
}
