using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    interface ISprite
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
