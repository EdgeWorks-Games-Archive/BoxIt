using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal sealed class TileTerrain : GameComponent
	{
		private readonly Tile[][] _tiles;

		public TileTerrain(Game game)
			: base(game)
		{
			_tiles = new Tile[16][];
			for (var i = 0; i < _tiles.Length; i++)
				_tiles[i] = new Tile[16];
		}

		public Texture2D Tileset { get; set; }

		public void Draw(IsoCamera camera, SpriteBatch spriteBatch)
		{
			// Start at the highest X since that's the one on top
			for (var x = _tiles.Length-1; x >= 0; x--)
			{
				for (var y = 0; y < _tiles[x].Length; y++)
				{
					spriteBatch.Draw(
						Tileset,
						camera.ToAbsolute(new Vector2(x, y)),
						new Rectangle(0, 0, 32, 32),
						Color.White,
						0f, new Vector2(0, 16 + 8), camera.Zoom,
						SpriteEffects.None, 0f);
				}
			}
		}
	}
}