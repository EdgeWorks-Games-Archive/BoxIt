using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace BoxIt.Content
{
	internal static class ContentExtensions
	{
		public static TileMap LoadMap(this ContentManager content, string assetName, IList<TileType> tileLookupTable, IList<WallType> wallLookupTable)
		{
			return new TileMap(content.Load<TileMapRaw>(assetName), tileLookupTable, wallLookupTable);
		}

		public static TileType[] LoadTileTypes(this ContentManager content, string assetName)
		{
			return content.Load<TileTypeRaw[]>(assetName).Select(t => new TileType(t)).ToArray();
		}

		public static WallType[] LoadWallTypes(this ContentManager content, string assetName)
		{
			return content.Load<WallTypeRaw[]>(assetName).Select(w => new WallType(w)).ToArray();
		}
	}
}