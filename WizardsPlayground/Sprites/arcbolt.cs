using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using WizardsPlayground.Sprites;
using WizardsPlayground.Models;

namespace WizardsPlayground.Sprites
{
    class arcbolt : Sprite
    {
        private float _timer;
        private float _animateTimer;
        private Random rand = new Random(System.DateTime.UtcNow.Second);
        public arcbolt(Texture2D texture, Texture2D texture2D) : base(texture, texture2D)
        {
        }

        public arcbolt(List<Texture2D> texture) : base(texture)
        {
        }

        public override void Update(GameTime GameTime, List<Sprite> sprite)
        {
            _timer += (float)GameTime.ElapsedGameTime.TotalSeconds;
            _animateTimer += (float)GameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > LifeSpan)
            {
                IsRemoved = true;
            }

            if (_animateTimer / .4f >= 1)
            {
                _animateTimer -= .4f;
                if (animation == 0)
                {
                    animation = 1;
                }
                else
                {
                    animation = 0;
                }
            }

            switch(rand.Next(3))
            {
                case 0:
                    Vector2 move = new Vector2(Direction.Y, Direction.X * (-1));
                    position += Direction * LinearVelocity + (move * LinearVelocity*2f);

                    break;
                case 1:
                    Vector2 mover = new Vector2(Direction.Y * (-1), Direction.X);
                    position += Direction * LinearVelocity + (mover * LinearVelocity*2f);
                    break;
                default:
                    position += Direction * LinearVelocity;
                    break;
            }
                
        }
    }
}
