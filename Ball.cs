using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Monogame_Pong
{
    class Ball
    {
        public Texture2D Texture;
        public Vector2 Position;
        public int BallSpeedX;
        public int BallSpeedY;
        public Rectangle CollisionRectangle;

        public Ball(Texture2D texture)
        {
            Texture = texture;
            Position = new Vector2((Game1.CLIENT_WIDTH / 2 - Texture.Width / 2), (Game1.CLIENT_HEIGHT / 2 - Texture.Height / 2));
            BallSpeedX = 3;
            BallSpeedY = 1;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        private void MoveBall()
        {
            Position.X += BallSpeedX;
            Position.Y += BallSpeedY;
            MoveCollisionBox();
        }

        public void ResetBall(string scorer)
        {
            Position.X = (Game1.CLIENT_WIDTH / 2 - Texture.Width / 2);
            Position.Y = (Game1.CLIENT_HEIGHT / 2 - Texture.Height / 2);
            BallSpeedX = 1;
            BallSpeedY = 1;
        }

        private void MoveCollisionBox()
        {
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        }

        public void Update()
        {
            MoveBall();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.End();
        }
    }
}
