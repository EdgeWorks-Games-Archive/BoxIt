using Microsoft.Xna.Framework;

namespace BoxIt
{
	internal class Camera
	{
		public Vector2 Position { get; set; }
		public int Zoom { get; set; }
		public Point Resolution { get; set; }
	}
}