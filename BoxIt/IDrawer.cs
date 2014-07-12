using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal interface IDrawer
	{
		void DrawTileMap(TileMap terrain, IsoCamera camera, SpriteBatch spriteBatch);
	}
}