using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;

namespace BoxIt.Windows
{
	public class BoxItWindowsPlatform : IBoxItPlatform
	{
		public DirectoryInfo FindAppDataDirectory()
		{
			// Find the user's application data directory
			var roaming = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			Debug.Assert(roaming.Exists);

			// Find our specific application data directory
			var appData = new DirectoryInfo(roaming + "/BoxIt");

			// If it exist, we're done
			if (appData.Exists)
				return appData;

			// If not, create it
			appData = roaming.CreateSubdirectory("BoxIt");
			Debug.Assert(appData.Exists);

			return appData;
		}

		public void ConfigureGraphicsDevice(GraphicsDeviceManager graphics)
		{
			graphics.PreferredBackBufferWidth = 1280;
			graphics.PreferredBackBufferHeight = 720;
		}
	}
}