using Microsoft.Xna.Framework;

namespace BoxIt
{
	internal class IsoCamera
	{
		private Point _halfTileSize;
		private Point _zoomedHalfTileSize;
		private int _zoom;

		public Vector2 Position { get; set; }
		public Point Resolution { get; set; }

		public int Zoom
		{
			get { return _zoom; }
			set
			{
				_zoom = value;
				_zoomedHalfTileSize = new Point(_halfTileSize.X * _zoom, _halfTileSize.Y * _zoom);
			}
		}

		public Point TileSize
		{
			set
			{
				_halfTileSize = new Point(value.X/2, value.Y/2);
				_zoomedHalfTileSize = new Point(_halfTileSize.X * _zoom, _halfTileSize.Y * _zoom);
			}
		}
		
		public Vector2 ToAbsolute(Vector2 position)
		{
			return new Vector2(
				(position.X * _zoomedHalfTileSize.X) + (position.Y * _zoomedHalfTileSize.X) - Position.X,
				(-position.X * _zoomedHalfTileSize.Y) + (position.Y * _zoomedHalfTileSize.Y) - Position.Y);
		}
	}
}