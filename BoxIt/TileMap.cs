using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal sealed class TileMap
	{
		public TileMap(TileMapRaw tileMap, IList<TileType> tileTypes)
		{
			// Transform our input data a bit
			var rawTiles = tileMap.Tiles.Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			var height = rawTiles.Length/tileMap.Width;

			// Initialize our map in advance
			Tiles = new Tile[tileMap.Width][];
			for (var x = 0; x < tileMap.Width; x++)
				Tiles[x] = new Tile[height];

			// Parse in the map
			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < tileMap.Width; x++)
				{
					Tiles[x][y].Type = tileTypes[int.Parse(rawTiles[(y*tileMap.Width) + x])];
				}
			}
		}

		public Tile[][] Tiles { get; set; }
		public Texture2D Tileset { get; set; }
	}
}