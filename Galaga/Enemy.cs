using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Galaga
{
    public class Enemy
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed = 150f;

        public Rectangle Bounds => new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);

        public Enemy(Texture2D texture, Vector2 startPosition)
        {
            _texture = texture;
            _position = startPosition;
        }

        public void Update(GameTime gameTime)
        {
            _position.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_position.Y > 600)
                _position.Y = -_texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
