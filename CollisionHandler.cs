using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Drawing;

namespace Monogame_Pong
{
    class CollisionHandler
    {
        private Ball _ball;
        private PlayerPallet _playerPallet;
        private AIPallet _aiPallet;
        private bool _palletHit;
        private Score _score;
        private int _timesHit;

        public CollisionHandler(PlayerPallet playerPallet, AIPallet aiPallet, Ball ball, Score score)
        {
            _ball = ball;
            _playerPallet = playerPallet;
            _aiPallet = aiPallet;
            _score = score;
        }

        private void CheckPalletCollision()
        {
            if (_playerPallet.CollisionRectangle.Intersects(_ball.CollisionRectangle) ||
                    _aiPallet.CollisionRectangle.Intersects(_ball.CollisionRectangle))
            {
                _palletHit = true;
                _timesHit++;
            }

            if(_palletHit)
            {
                if (_timesHit == 3)
                {
                    if (_ball.BallSpeedX > 0)
                    {
                        _ball.BallSpeedX++;
                    }
                    else if (_ball.BallSpeedX < 0)
                    {
                        _ball.BallSpeedX--;
                    }

                    _timesHit = 0;
                }

                _ball.BallSpeedX = -_ball.BallSpeedX;
                _palletHit = false;
            }
        }

        private void CheckWallCollision()
        {
            if(_ball.Position.Y > Game1.CLIENT_HEIGHT - _ball.Texture.Height || _ball.Position.Y < 0)
            {
                _ball.BallSpeedY = -_ball.BallSpeedY;
            }
            else if(_ball.Position.X > Game1.CLIENT_WIDTH - _ball.Texture.Width)
            {
                _score.AddToScore("player");
                _ball.ResetBall("player");
            }
            else if(_ball.Position.X < 0)
            {
                _score.AddToScore("ai");
                _ball.ResetBall("ai");
            }
        }
        public void Update()
        {
            CheckPalletCollision();
            CheckWallCollision();
        }
    }
}
