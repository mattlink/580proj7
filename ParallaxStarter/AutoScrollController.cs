using System;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    class AutoScrollController : IScrollController
    {
        float elapsedTime = 0;
        public float speed = 10f;

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(-elapsedTime * speed, 0, 0);
            }
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
