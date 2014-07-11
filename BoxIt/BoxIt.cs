using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoxIt
{
	/// <summary>
	///     This is the main type for your game
	/// </summary>
	public sealed class BoxIt : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private IsoCamera _camera;
		private IDrawer _drawer;
		private SpriteBatch _spriteBatch;
		private TileTerrain _terrain;

		public BoxIt()
		{
			Trace.AutoFlush = true;

			// Find the user's application data directory
			var roaming = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			Debug.Assert(roaming.Exists);

			// Find our specific application data directory
			var appData = new DirectoryInfo(roaming + "/BoxIt");

			// If it doesn't exist, create it
			if (!appData.Exists)
			{
				appData = roaming.CreateSubdirectory("BoxIt");
				Debug.Assert(appData.Exists);
			}

			// Add a log target file and log execution start
			Trace.Listeners.Add(new TextWriterTraceListener(appData + "/BoxIt.log", "logWriterListener"));
			Trace.WriteLine("");
			Trace.TraceInformation(" === Execution Start = {0} ===", DateTime.Now.ToString("O"));
			Trace.TraceInformation("BoxIt application data location: " + appData.FullName);


			// Configure default settings
			IsMouseVisible = true;
			Content.RootDirectory = "Content";

			_graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 720
			};
		}

		/// <summary>
		///     Allows the game to perform any initialization it needs to before starting to run.
		///     This is where it can query for any required services and load any non-graphic
		///     related content. Calling base.Initialize will enumerate through any components
		///     and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			_camera = new IsoCamera
			{
				Position = new Vector2(-160, -320),
				Resolution = new Point(
					_graphics.PreferredBackBufferWidth,
					_graphics.PreferredBackBufferHeight),
				Zoom = 2,
				TileSize = new Point(32, 16)
			};

			_terrain = new TileTerrain(this);
			Components.Add(_terrain);

			base.Initialize();
		}

		/// <summary>
		///     LoadContent will be called once per game and is the place to load
		///     all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new graphics related objects
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			_drawer = new StandardDrawer();

			_terrain.Tileset = Content.Load<Texture2D>("Graphics/Tileset");
		}

		/// <summary>
		///     UnloadContent will be called once per game and is the place to unload
		///     all content.
		/// </summary>
		protected override void UnloadContent()
		{
		}

		/// <summary>
		///     Allows the game to run logic such as updating the world,
		///     checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}

		/// <summary>
		///     This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin(
				SpriteSortMode.Deferred, BlendState.AlphaBlend,
				SamplerState.PointClamp, DepthStencilState.None,
				RasterizerState.CullCounterClockwise);

			_drawer.DrawTerrain(_terrain, _camera, _spriteBatch);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}