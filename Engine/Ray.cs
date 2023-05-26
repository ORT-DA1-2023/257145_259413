using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	internal class Ray
	{

		private Vector _origin;
		private Vector _direction;

		public Ray(Vector origin, Vector direction)
		{
			_origin = origin;
			_direction = direction;
		}
		public Vector Origin
		{
			get { return this._origin; }
			set { this._origin = value; }
		}
		public Vector Direction
		{
			get { return this._direction; }
			set { this._direction = value; }
		}

		public Vector PointAt(double i)
		{
			return this.Origin.Add(this.Direction.Multiply(i));
		}
	}
}
