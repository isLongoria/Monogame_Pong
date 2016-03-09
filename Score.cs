using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Pong
{
    class Score
    {
        public int PlayerScore = 0;
        public int AIScore = 0;
        private SpriteFont _spriteFont;
        private Vector2 _playerScorePosition;
        private Vector2 _aiScorePosition;

        public Score(SpriteFont spriteFont)
        {
            _spriteFont = spriteFont;
            _playerScorePosition = new Vector2(Game1.CLIENT_WIDTH / 2 - Game1.CLIENT_WIDTH / 6, Game1.CLIENT_HEIGHT / 22);
            _aiScorePosition = new Vector2(Game1.CLIENT_WIDTH / 2 + Game1.CLIENT_WIDTH / 8, Game1.CLIENT_HEIGHT / 22);
        }

        public void AddToScore(string scorer)
        {
            switch (scorer)
            {
                case "player":
                    PlayerScore++;
                    break;
                case "ai":
                    AIScore++;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_spriteFont, PlayerScore.ToString(), _playerScorePosition, Color.White);
            spriteBatch.DrawString(_spriteFont, AIScore.ToString(), _aiScorePosition, Color.White);
            spriteBatch.End();
        }
    }
}
