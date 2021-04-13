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
    class firebolt : Sprite
    {
        private float _timer;
        private float _animateTimer;
        public firebolt(Texture2D texture, Texture2D texture2D) : base(texture, texture2D)
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

            if(_animateTimer / .2f >= 1 )
            {
                _animateTimer -= .2f;
                if (animation == 0)
                {
                    animation = 1;
                }
                else
                {
                    animation = 0;
                }
                 
                
            }
            position += Direction * LinearVelocity;
        }
    }
}
