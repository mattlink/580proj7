using System;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    interface IScrollController
    {
        Matrix Transform { get; }
        void Update(GameTime gameTime);
    }
}
