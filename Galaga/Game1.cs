using Galaga.GameObjects;
using Galaga.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Galaga
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player _player;
        private EnemyManager _enemyManager;
        private List<Bullet> _bullets;

        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Texture2D _bulletTexture;
        private Texture2D _heartTexture;
        private Texture2D _backgroundTexture;
        private Texture2D _scoreBackgroundTexture;  // Fondo del cartel de puntaje

        private bool _canShoot = true;
        private Rectangle _mapBounds;
        private int _score;
        private SpriteFont _scoreFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _score = 0;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTexture = Content.Load<Texture2D>("player");
            _enemyTexture = Content.Load<Texture2D>("enemy");
            _bulletTexture = Content.Load<Texture2D>("bullet");
            _heartTexture = Content.Load<Texture2D>("heart");
            _backgroundTexture = Content.Load<Texture2D>("fondo");
            _scoreBackgroundTexture = Content.Load<Texture2D>("scoreBackground"); // Carga el fondo del cartel

            _scoreFont = Content.Load<SpriteFont>("ScoreFont");  // Asegúrate de tener un archivo ScoreFont.spritefont

            _player = new Player(_playerTexture, new Vector2(400, 500));
            _enemyManager = new EnemyManager(_enemyTexture);
            _bullets = new List<Bullet>();

            _mapBounds = new Rectangle(0, 0, 1280, 720);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.A))
                movement.X -= 1;

            if (keyboardState.IsKeyDown(Keys.D))
                movement.X += 1;

            if (keyboardState.IsKeyDown(Keys.W))
                movement.Y -= 1;

            if (keyboardState.IsKeyDown(Keys.S))
                movement.Y += 1;

            if (movement != Vector2.Zero)
                movement.Normalize();

            if (keyboardState.IsKeyDown(Keys.Space) && _canShoot)
            {
                _bullets.Add(new Bullet(_bulletTexture, new Vector2(_player.Position.X + 20, _player.Position.Y)));
                _canShoot = false;
            }

            if (keyboardState.IsKeyUp(Keys.Space))
            {
                _canShoot = true;
            }

            _player.Update(gameTime);
            _enemyManager.Update(gameTime);

            foreach (var bullet in _bullets)
                bullet.Update(gameTime);

            _bullets.RemoveAll(b => b.Bounds.Bottom < 0);

            HandleCollisions();

            if (_player.Lives <= 0)
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);

            // Dibujar el cartel de puntaje en la parte superior de la pantalla
            int scoreBarHeight = 60; // Altura del cartel
            _spriteBatch.Draw(_scoreBackgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, scoreBarHeight), Color.Gray);

            // Dibujar el puntaje sobre el fondo
            _spriteBatch.DrawString(_scoreFont, "Score: " + _score, new Vector2(20, 20), Color.White);

            _player.Draw(_spriteBatch);
            _enemyManager.Draw(_spriteBatch);

            foreach (var bullet in _bullets)
                bullet.Draw(_spriteBatch);

            // Dibujar las vidas
            float heartSize = 0.25f;
            int heartSpacing = 5;
            int heartWidth = (int)(_heartTexture.Width * heartSize);
            int heartHeight = (int)(_heartTexture.Height * heartSize);

            for (int i = 0; i < _player.Lives; i++)
            {
                int x = 10 + i * (heartWidth + heartSpacing);
                int y = _graphics.PreferredBackBufferHeight - heartHeight - 10;
                _spriteBatch.Draw(_heartTexture, new Vector2(x, y), null, Color.White, 0f, Vector2.Zero, heartSize, SpriteEffects.None, 0f);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleCollisions()
        {
            var enemiesToRemove = new List<Enemy>();
            var bulletsToRemove = new List<Bullet>();

            foreach (var bullet in _bullets)
            {
                foreach (var enemy in _enemyManager.Enemies)
                {
                    if (bullet.Bounds.Intersects(enemy.Bounds))
                    {
                        bulletsToRemove.Add(bullet);
                        enemiesToRemove.Add(enemy);
                        _score += 10;  // Aumenta el puntaje por cada enemigo eliminado
                    }
                }
            }

            foreach (var enemy in _enemyManager.Enemies)
            {
                if (_player.Bounds.Intersects(enemy.Bounds))
                {
                    _player.TakeDamage();
                    enemiesToRemove.Add(enemy);
                }
            }

            foreach (var bullet in bulletsToRemove)
                _bullets.Remove(bullet);

            foreach (var enemy in enemiesToRemove)
                _enemyManager.Enemies.Remove(enemy);
        }
    }
}
