using Microsoft.Xna.Framework.Graphics;

namespace BoxIt
{
	internal interface IDrawer
	{
		void DrawTerrain(TileTerrain terrain, IsoCamera camera, SpriteBatch spriteBatch);
	}
}