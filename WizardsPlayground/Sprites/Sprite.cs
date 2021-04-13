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
    class Sprite : ICloneable
    {
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        protected MouseState _previousMouse;
        protected MouseState _currentMouse;
        protected List<Texture2D> _texture = new List<Texture2D>();

        public Vector2 position;
        public Vector2 Origin;
        public Vector2 Direction;
        public float Rotation;
        public float RotationalVelocity = 3f;
        public float LinearVelocity = 4f;
        public float Speed = 0f;
        public float LifeSpan;
        public bool IsRemoved = false;
        public int animation = 0;

        public Sprite Parent;


        public Sprite(Texture2D texture)
        {
            _texture.Add(texture);
        }

        public Sprite(List<Texture2D> texture)
        {
            _texture = texture;
        }

        public Sprite(Texture2D texture, Texture2D texture2D)
        {

            _texture.Add(texture);
            _texture.Add(texture2D);
        }

        public Rectangle Rectangle
        {
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)position.X - (int)Origin.X, (int)position.Y - (int)Origin.Y, _texture[animation].Width, _texture[animation].Height);
                }
                throw new Exception("unknown sprite");
            }
        }

        public Texture2D Texture2D { get; }

        public virtual void Update(GameTime GameTime, List<Sprite> sprite)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture[animation], position, null, Color.White, Rotation, Origin, 1.0f, SpriteEffects.None, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
