using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace BoxIt
{
	internal static class ContentExtensions
	{
		public static TileMap LoadMap(this ContentManager content, string assetName, IList<TileType> typeLookupTable)
		{
			return new TileMap(content.Load<TileMapRaw>(assetName), typeLookupTable);
		}

		public static TileType[] LoadTileTypes(this ContentManager content, string assetName)
		{
			return content.Load<TileTypeRaw[]>(assetName).Select(t => new TileType(t)).ToArray();
		}
	}
}