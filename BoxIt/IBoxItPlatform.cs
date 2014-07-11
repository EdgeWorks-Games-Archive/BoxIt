using System.IO;
using Microsoft.Xna.Framework;

namespace BoxIt
{
	public interface IBoxItPlatform
	{
		DirectoryInfo FindAppDataDirectory();
		void ConfigureGraphicsDevice(GraphicsDeviceManager graphics);
	}
}