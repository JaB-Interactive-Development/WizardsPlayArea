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
        public arcbolt arcbolt;

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
            RightClick(sprites);
            LeftClick(sprites);
        }

        private void LeftClick(List<Sprite> sprites)
        {
            if(_currentMouse.RightButton != _previousMouse.RightButton && _currentMouse.RightButton == ButtonState.Pressed)
            {
                var Arcbolt = arcbolt.Clone() as arcbolt;
                Arcbolt.Direction = Vector2.Normalize(this.Direction);
                Arcbolt.position = this.position;
                Arcbolt.Rotation = this.Rotation;
                Arcbolt.LinearVelocity = this.LinearVelocity * 1.25f;
                Arcbolt.LifeSpan = 2f;
                Arcbolt.Parent = this;

                sprites.Add(Arcbolt);
            }
        }

        private void RightClick(List<Sprite> sprites)
        {
            if(_currentMouse.LeftButton != _previousMouse.LeftButton && _currentMouse.LeftButton == ButtonState.Pressed)
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
