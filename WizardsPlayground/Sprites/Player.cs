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
        public Player(Texture2D texture) : base(texture)
        {
            _position = new Vector2(30, 40);
            Speed = 3f;
        }

        public override void Update(GameTime GameTime, List<Sprite> sprite)
        {
            Move();
            Rotate();
        }

        private void Rotate()
        {
            var mouspos = Mouse.GetState();
            Direction = mouspos.Position.ToVector2() - _position;
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X);

        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if ((_position.Y -= Speed) >= 0)
                    _position.Y -= Speed;
                else
                    _position.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if ((_position.Y += Speed) <= Game1.ScreenY - _texture.Height)
                    _position.Y += Speed;
                else
                    _position.Y = Game1.ScreenY - _texture.Height;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if ((_position.X -= Speed) >= 0)
                    _position.X -= Speed;
                else
                    _position.X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if ((_position.X += Speed) <= Game1.ScreenX - _texture.Width)
                    _position.X += Speed;
                else
                    _position.X = Game1.ScreenX - _texture.Width;
            }
        }
    }
}
