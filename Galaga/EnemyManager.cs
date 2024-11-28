using Galaga.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Galaga.Managers
{
    public class EnemyManager
    {
        private List<Enemy> _enemies;
        private Texture2D _enemyTexture;
        private Random _random;
        private float _spawnTimer;
        private float _spawnInterval = 1.5f;

        public List<Enemy> Enemies => _enemies;


        public EnemyManager(Texture2D enemyTexture)
        {
            _enemies = new List<Enemy>();
            _enemyTexture = enemyTexture;
            _random = new Random();
        }


        public void Update(GameTime gameTime)
        {
            _spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_spawnTimer >= _spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0f;
            }

            foreach (var enemy in _enemies)
            {
                enemy.Update(gameTime);
            }


            _enemies.RemoveAll(e => e.Bounds.Top > 720);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        private void SpawnEnemy()
        {

            int xPosition = _random.Next(0, 1280 - _enemyTexture.Width);
            int yPosition = -_enemyTexture.Height;

            _enemies.Add(new Enemy(_enemyTexture, new Vector2(xPosition, yPosition)));
        }

    }
}