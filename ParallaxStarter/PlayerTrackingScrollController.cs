using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    class PlayerTrackingScrollController : IScrollController
    {

        // the player we're tracking
        Player player;

        public float ScrollRatio = 1.0f;
        public float Offset = 200;

        public Matrix Transform
        {
            get
            {
                if (player.Position.X < 200) return Matrix.Identity;
                float x = ScrollRatio * (Offset - player.Position.X);
                return Matrix.CreateTranslation(x, 0, 0);
            }
        }

        public void Update(GameTime gameTime) { }

        public PlayerTrackingScrollController(Player player, float ratio)
        {
            this.player = player;
            this.ScrollRatio = ratio;
        }


    }
}
