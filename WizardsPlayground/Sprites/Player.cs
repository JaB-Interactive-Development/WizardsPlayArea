using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using WizardsPlayground.Sprites;
using WizardsPlayground.Models;
using WizardsPlayground;

namespace WizardsPlayground.Sprites
{
    class Player : Sprite
    {
        public bool HasDied = false;
        public firebolt firebolt;

        public Player(Texture2D texture) : base(texture)
        {
            position = new Vector2(30, 40);
            Speed = 3f;
        }

        public override void Update(GameTime GameTime, List<Sprite> sprites)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            Move();
            Rotate();
            Attack(sprites);
        }

        private void Attack(List<Sprite> sprites)
        {
            if(_currentMouse.LeftButton != _previousMouse.LeftButton)
            {
                var Firebolt = firebolt.Clone() as firebolt;
                Firebolt.Direction = Vector2.Normalize(this.Direction);
                Firebolt.position = this.position;
                Firebolt.Rotation = this.Rotation;
                Firebolt.LinearVelocity = this.LinearVelocity*2;
                Firebolt.LifeSpan = 2f;
                Firebolt.Parent = this;

                sprites.Add(Firebolt);
                
            }
        }

        private void Rotate()
        {
            Direction = _currentMouse.Position.ToVector2() - position;
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X) - ((float)Math.PI / 2);

        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if ((position.Y -= Speed) >= 0)
                    position.Y -= Speed;
                else
                    position.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if ((position.Y += Speed) <= Game1.ScreenHeight - _texture[animation].Height)
                    position.Y += Speed;
                else
                    position.Y = Game1.ScreenHeight - _texture[animation].Height;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if ((position.X -= Speed) >= 0)
                    position.X -= Speed;
                else
                    position.X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if ((position.X += Speed) <= Game1.ScreenHeight - _texture[animation].Width)
                    position.X += Speed;
                else
                    position.X = Game1.ScreenHeight - _texture[animation].Width;
            }
        }
    }
}
