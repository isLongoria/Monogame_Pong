using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Pong
{
    class PlayerPallet : Pallets
    {
        public PlayerPallet(Texture2D texture) : base(texture)
        {
            Position.X = Texture.Width / 2;
            Position.Y = Game1.CLIENT_HEIGHT / 2 - Texture.Height / 2;
        }

        protected override void MovePallet()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                if(Position.Y > 0)
                {
                    Position.Y -= 2;
                }
            }

            else if (state.IsKeyDown(Keys.Down))
            {
                if(Position.Y < Game1.CLIENT_HEIGHT - Texture.Height)
                {
                    Position.Y += 2;
                }
                
            }

            base.MovePallet();
        }

    }
}
