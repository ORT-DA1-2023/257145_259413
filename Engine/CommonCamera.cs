using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	internal class CommonCamera : Camera
	{

		private Vector _origin;
		private Vector _corner_lowerLeft;
		private Vector _horizontal;
		private Vector _vertical;
		private double _lensRadius;
		private double _focalDistance;
		public Vector vectorW;
		public Vector vectorU;
		public Vector vectorV;

		public CommonCamera(Vector lookFrom, Vector lookAt, Vector up, int FoV, double aspectRatio)
		{
			double theta = FoV * Math.PI / 180;
			double heightHalf = Math.Tan(theta / 2);
			double widthHalf = aspectRatio * heightHalf;
			this._origin = lookFrom;
			this.vectorW = lookFrom.Subtract(lookAt).getUnit();
			this.vectorU = up.Cross(this.vectorW).getUnit();
			this.vectorV = this.vectorW.Cross(this.vectorU);
			this._corner_lowerLeft = this._origin
				.Subtract(this.vectorU.Multiply(widthHalf))
				.Subtract(this.vectorV.Multiply(heightHalf))
				.Subtract(this.vectorW);
			this._horizontal = this.vectorU.Multiply(2 * widthHalf);
			this._vertical = this.vectorV.Multiply(2 * heightHalf);
		}

		public override Ray getRay(double u, double v)
		{
			Vector horizontalPosition = this._horizontal.Multiply(u);
			Vector verticalPosition = this._vertical.Multiply(v);
			return new Ray(this._origin, this._corner_lowerLeft.Add(horizontalPosition.Add(verticalPosition)).Subtract(this._origin));

		}

	}
}
