using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Pong
{
    class AIPallet : Pallets
    {
        public AIPallet(Texture2D texture) : base(texture)
        {
            Position.X = Game1.CLIENT_WIDTH - (Texture.Width + Texture.Width / 2);
            Position.Y = Game1.CLIENT_HEIGHT / 2 - Texture.Height / 2;
        }

        private void MovePallet(Vector2 ballPosition)
        {
            if (ballPosition.X >= Game1.CLIENT_WIDTH / 3)
            {
                if(ballPosition.Y > Position.Y + Texture.Height / 2)
                {
                    if(Position.Y < Game1.CLIENT_HEIGHT - Texture.Height)
                    {
                        Position.Y += 1;
                    }
                }
                else if(ballPosition.Y < Position.Y)
                {
                    if(Position.Y > 0)
                    {
                        Position.Y-= 1;
                    }                    
                }
            }

            base.MovePallet();
        }

        public void Update(Vector2 ballPosition)
        {
            MovePallet(ballPosition);
        }
    }
}
