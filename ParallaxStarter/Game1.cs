using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ParallaxStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.GraphicsProfile = GraphicsProfile.HiDef;

            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 192;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var repeatCount = 5;
            var scale = 1.4f;

            var spritesheet = Content.Load<Texture2D>("helicopter");
            player = new Player(spritesheet);

            var playerLayer = new ParallaxLayer(this);
            playerLayer.Sprites.Add(player);
            playerLayer.DrawOrder = 4;

            // we want to loop this background
            var backgroundTexture = Content.Load<Texture2D>("forest_back");
            var backgroundSprites = new List<StaticSprite>();
            for (var i = 0; i < repeatCount; i++) backgroundSprites.Add(new StaticSprite(backgroundTexture, new Vector2(i * 272, 0)));
            var backgroundLayer = new ParallaxLayer(this);
            backgroundLayer.Sprites.AddRange(backgroundSprites);
            backgroundLayer.DrawOrder = 0;

            var lightTexture = Content.Load<Texture2D>("forest_light");
            var lightSprites = new List<StaticSprite>();
            for (var i = 0; i < repeatCount; i++) lightSprites.Add(new StaticSprite(lightTexture, new Vector2(i * 272, 0)));
            var lightLayer = new ParallaxLayer(this);
            lightLayer.Sprites.AddRange(lightSprites);
            lightLayer.DrawOrder = 1;

            var midTexture = Content.Load<Texture2D>("forest_mid");
            var midSprites = new List<StaticSprite>();
            for (var i = 0; i < repeatCount; i++) midSprites.Add(new StaticSprite(midTexture, new Vector2(i * 272, 0)));
            var midLayer = new ParallaxLayer(this);
            midLayer.Sprites.AddRange(midSprites);
            midLayer.DrawOrder = 2;

            var frontTexture = Content.Load<Texture2D>("forest_front");
            var frontSprites = new List<StaticSprite>();
            for (var i = 0; i < repeatCount; i++) frontSprites.Add(new StaticSprite(frontTexture, new Vector2(i * 272, 0)));
            var frontLayer = new ParallaxLayer(this);
            frontLayer.Sprites.AddRange(frontSprites);
            frontLayer.DrawOrder = 3;

            backgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.1f);
            lightLayer.ScrollController = new PlayerTrackingScrollController(player, 0.2f);
            midLayer.ScrollController = new PlayerTrackingScrollController(player, .3f);
            frontLayer.ScrollController = new PlayerTrackingScrollController(player, .4f);
            playerLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);

            backgroundLayer.Scale = Matrix.CreateScale(scale);
            lightLayer.Scale = Matrix.CreateScale(scale);
            midLayer.Scale = Matrix.CreateScale(scale);
            frontLayer.Scale = Matrix.CreateScale(scale);

            Components.Add(backgroundLayer);
            Components.Add(lightLayer);
            Components.Add(midLayer);
            Components.Add(frontLayer);
            Components.Add(playerLayer);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
