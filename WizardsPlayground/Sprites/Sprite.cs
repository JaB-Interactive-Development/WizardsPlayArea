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
    class Sprite
    {
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        protected Texture2D _texture;

        public Vector2 _position;
        public Vector2 Origin;
        public Color Colour = Color.White;
        public float Speed = 0f;
        public float LifeSpan;
        public bool IsRemoved = false;


        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)_position.X - (int)Origin.X, (int)_position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
                }
                throw new Exception("unknown sprite");
            }
        }

        public virtual void Update(GameTime GameTime, List<Sprite> sprite)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
