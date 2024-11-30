using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Galaga
{
    public class Enemy
    {
        private Texture2D textura;
        private Vector2 posicion;
        private float velocidad = 350f;

        public Rectangle Bounds => new Rectangle((int)posicion.X, (int)posicion.Y, textura.Width, textura.Height);

        public Enemy(Texture2D texture, Vector2 startPosition)
        {
            textura = texture;
            posicion = startPosition;
        }

        public void Update(GameTime gameTime)
        {
            posicion.Y += velocidad * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (posicion.Y > 1920)
                posicion.Y = -textura.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicion, Color.White);
        }
    }
}
