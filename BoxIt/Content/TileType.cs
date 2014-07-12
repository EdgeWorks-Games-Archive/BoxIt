using System.Linq;
using Microsoft.Xna.Framework;

namespace BoxIt.Content
{
	internal sealed class TileType
	{
		public TileType(TileTypeRaw raw)
		{
			Name = raw.Name;
			HeightOffset = raw.HeightOffset;

			var texLoc = raw.TextureLocation.Split(' ').Select(int.Parse).ToArray();
			TextureLocation = new Point(texLoc[0], texLoc[1]);
		}

		public string Name { get; set; }
		public Point TextureLocation { get; set; }
		public int HeightOffset { get; set; }
	}
}