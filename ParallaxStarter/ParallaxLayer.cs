using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    class ParallaxLayer : DrawableGameComponent
    {
        public List<ISprite> Sprites = new List<ISprite>();

        public IScrollController ScrollController { get; set; } = new AutoScrollController();

        SpriteBatch spriteBatch;

        public Matrix Scale = Matrix.CreateScale(1.0f);

        public bool ScrollStop = false;

        public ParallaxLayer(Game game) : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            ScrollController.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //if (ScrollStop) spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, this.Scale);
            //else spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, ScrollController.Transform + this.Scale);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, ScrollController.Transform + this.Scale);
            foreach (var sprite in Sprites)
            {
                sprite.Draw(spriteBatch, gameTime);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
