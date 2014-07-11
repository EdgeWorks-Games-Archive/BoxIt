using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal sealed class TileTerrain : GameComponent
	{
		public TileTerrain(Game game)
			: base(game)
		{
			Tiles = new Tile[16][];
			for (var i = 0; i < Tiles.Length; i++)
				Tiles[i] = new Tile[16];
		}

		public Tile[][] Tiles { get; set; }
		public Texture2D Tileset { get; set; }
	}
}