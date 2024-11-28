using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Galaga.GameObjects
{
    public class Player
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed = 350f;
        private int _lives;

        public Rectangle Bounds => new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);

        public Vector2 Position => _position;
        public int Lives => _lives;

        
        public Player(Texture2D texture, Vector2 startPosition)
        {
            _texture = texture;
            _position = startPosition;
            _lives = 3; 
        }

        
        public void TakeDamage()
        {
            _lives--;
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

           
            if (keyboardState.IsKeyDown(Keys.A))
                _position.X -= _speed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.D))
                _position.X += _speed * deltaTime;

            
            _position.X = MathHelper.Clamp(_position.X, 0, 1920 - _texture.Width); 
            _position.Y = MathHelper.Clamp(_position.Y, 0, 1080 - _texture.Height); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
