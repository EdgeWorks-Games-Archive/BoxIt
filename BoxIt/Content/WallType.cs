using System.Linq;
using Microsoft.Xna.Framework;

namespace BoxIt.Content
{
	internal sealed class WallType
	{
		public WallType(WallTypeRaw raw)
		{
			Name = raw.Name;
			HeightOffset = raw.HeightOffset;
			HasTop = raw.HasTop;

			// Parse in the location of the texture
			var texLoc = raw.TextureLocation.Split(' ').Select(int.Parse).ToArray();
			TextureLocation = new Point(texLoc[0], texLoc[1]);

			// If it doesn't have a top we're done
			if (!HasTop) return;

			// It does has a top, so we need to parse in the location of that as well
			texLoc = raw.TopTextureLocation.Split(' ').Select(int.Parse).ToArray();
			TopTextureLocation = new Point(texLoc[0], texLoc[1]);
		}

		public string Name { get; set; }
		public Point TextureLocation { get; set; }
		public int HeightOffset { get; set; }

		public bool HasTop { get; set; }
		public Point TopTextureLocation { get; set; }
	}
}