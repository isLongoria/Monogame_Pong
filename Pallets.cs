using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Pong
{
    class Pallets
    {
        // protected es para que solo la clase y sus heredados puedan verlos.
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle CollisionRectangle;

        public Pallets(Texture2D texture)
        {
            Texture = texture;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        /// <summary>
        /// Logica para mover la pallet. Se va a estar llamando en Update()
        /// </summary>
        protected virtual void MovePallet()
        {
            MoveCollisionBox();
        }

        protected virtual void MoveCollisionBox()
        {
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        }

        public virtual void Update()
        {
            MovePallet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.End();
        }
    }
}
