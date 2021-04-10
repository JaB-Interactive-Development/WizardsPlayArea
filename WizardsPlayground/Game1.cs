using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WizardsPlayground
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;
        private Vector2 _position;
        private int _screenX;
        private int _screenY;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            //_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = Content.Load<Texture2D>("GreenWizard");
            _position = new Vector2(0, 0);
            _screenY = GraphicsDevice.Viewport.Height;
            _screenX = GraphicsDevice.Viewport.Width;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if((_position.Y -= 5) >= 0)
                _position.Y -= 5;
                else
                _position.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if ((_position.Y += 5) <= _screenY)
                    _position.Y += 5;
                else
                    _position.Y = _screenY;
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
                if ((_position.X += 5) <= _screenX)
                    _position.X += 5;
                else
                    _position.X = _screenX;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture,_position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
