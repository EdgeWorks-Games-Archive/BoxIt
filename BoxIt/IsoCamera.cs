using Microsoft.Xna.Framework;

namespace BoxIt
{
	internal class IsoCamera
	{
		private Point _halfTileSize;

		public Vector2 Position { get; set; }
		public int Zoom { get; set; }
		public Point Resolution { get; set; }

		public Point TileSize
		{
			set { _halfTileSize = new Point(value.X/2, value.Y/2); }
		}
		
		public Vector2 ToAbsolute(Vector2 position)
		{
			return new Vector2(
				(position.X * _halfTileSize.X * Zoom) + (position.Y * _halfTileSize.X * Zoom) - Position.X,
				(-position.X * _halfTileSize.Y * Zoom) + (position.Y * _halfTileSize.Y * Zoom) - Position.Y);
		}
	}
}