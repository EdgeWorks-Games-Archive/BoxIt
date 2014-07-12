using BoxIt.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal class StandardDrawer : IDrawer
	{
		// The plan with this drawer class is that later on it can be replaced with
		// different drawer class types to create different effects. For example,
		// a DesignDrawer would draw tiles in a blueprint style.

		public void DrawTileMap(TileMap terrain, IsoCamera camera, SpriteBatch spriteBatch)
		{
			// Start at the highest X since that's the one on top
			for (var x = terrain.Tiles.Length - 1; x >= 0; x--)
			{
				for (var y = 0; y < terrain.Tiles[x].Length; y++)
				{
					var tile = terrain.Tiles[x][y];

					if (tile.Type != null)
					{
						spriteBatch.Draw(
							terrain.Tileset,
							camera.ToAbsolute(new Vector2(x, y)),
							new Rectangle(
								tile.Type.TextureLocation.X, tile.Type.TextureLocation.Y,
								32, 32),
							Color.White,
							0f, new Vector2(0, 24 + tile.Type.HeightOffset), camera.Zoom,
							SpriteEffects.None, 0f);
					}

					// We need to draw wall tops part of bordering tiles first
					// This is done in this tile instead of the tile it's a top of because otherwise
					// objects moving into the tile would overlap the top when not part of the tile yet.
					// TODO: Separate tops for separate directions
					if (x < (terrain.Tiles.Length - 1))
					{
						var borderTile = terrain.Tiles[x + 1][y];
						if (borderTile.Wall != null &&
							borderTile.Wall.HasTop)
						{
							spriteBatch.Draw(
								terrain.Tileset,
								camera.ToAbsolute(new Vector2(x+1, y)),
								new Rectangle(
									borderTile.Wall.TopTextureLocation.X, borderTile.Wall.TopTextureLocation.Y,
									32, 96),
								Color.White,
								0f, new Vector2(0, 64 + 24 + borderTile.Wall.HeightOffset), camera.Zoom,
								SpriteEffects.None, 0f);
						}
					}

					if (tile.Wall != null)
					{
						spriteBatch.Draw(
							terrain.Tileset,
							camera.ToAbsolute(new Vector2(x, y)),
							new Rectangle(
								tile.Wall.TextureLocation.X, tile.Wall.TextureLocation.Y,
								32, 96),
							Color.White,
							0f, new Vector2(0, 64 + 24 + tile.Wall.HeightOffset), camera.Zoom,
							SpriteEffects.None, 0f);
					}

					// Draw objects part of the tile here
				}
			}
		}
	}
}