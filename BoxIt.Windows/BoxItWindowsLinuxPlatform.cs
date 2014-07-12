using Microsoft.Xna.Framework;

namespace BoxIt.Windows
{
	public class BoxItWindowsPlatform : IBoxItPlatform
	{
		public void ConfigureGraphicsDevice(GraphicsDeviceManager graphics)
		{
			graphics.PreferredBackBufferWidth = 1280;
			graphics.PreferredBackBufferHeight = 720;
		}
	}
}