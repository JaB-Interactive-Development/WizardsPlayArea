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
            Speed = 5f;
        }

        public override void Update(GameTime GameTime, List<Sprite> sprite)
        {
            Move();
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if ((_position.Y -= 5) >= 0)
                    _position.Y -= 5;
                else
                    _position.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if ((_position.Y += 5) <= Game1.ScreenY - _texture.Height)
                    _position.Y += 5;
                else
                    _position.Y = Game1.ScreenY - _texture.Height;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if ((_position.X -= 5) >= 0)
                    _position.X -= 5;
                else
                    _position.X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if ((_position.X += 5) <= Game1.ScreenX - _texture.Width)
                    _position.X += 5;
                else
                    _position.X = Game1.ScreenX - _texture.Width;
            }
        }
    }
}
