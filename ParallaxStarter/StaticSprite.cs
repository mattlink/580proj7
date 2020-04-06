using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    class StaticSprite : ISprite
    {
        public Vector2 position = Vector2.Zero;

        Texture2D texture;

        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            this.position = position;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
