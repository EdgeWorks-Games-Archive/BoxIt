using System;

namespace BoxIt.Windows
{
	public static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			using (var game = new BoxIt(new BoxItWindowsPlatform()))
				game.Run();
		}
	}
}