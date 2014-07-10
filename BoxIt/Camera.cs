using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BoxIt
{
	internal class Camera
	{
		private Point _resolution;

		public double Ratio { get; private set; }
		public Vector2 Position { get; set; }
		public Point Size { get; private set; }

		public int Height
		{
			set { Size = new Point((int)Math.Round(value * Ratio), value); }
		}
		public Point Resolution
		{
			get { return _resolution; }
			set
			{
				_resolution = value;
				Ratio = _resolution.X / _resolution.Y;
			}
		}
	}
}
