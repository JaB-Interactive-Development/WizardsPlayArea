using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using WizardsPlayground.Sprites;
using WizardsPlayground.Models;

namespace WizardsPlayground
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Sprite> _sprites;

        public Texture2D Texture;
        public Vector2 Position;
        public static int ScreenWidth;
        public static int ScreenHeight;

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
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenHeight = GraphicsDevice.Viewport.Width;

            var gWizard = Content.Load<Texture2D>("GreenWizard");
            _sprites = new List<Sprite>()
            {
                new Player(gWizard)
                {
                    position = new Vector2(100,100),
                    Origin = new Vector2(gWizard.Width/2,gWizard.Height/2),
                    firebolt = new firebolt(Content.Load<Texture2D>( "firebolt_1"),Content.Load<Texture2D>("firebolt_2")),
                }
            };
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            for(int i =0; i < _sprites.Count; i++)
            {
                if(_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSeaGreen);

            _spriteBatch.Begin();
            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
