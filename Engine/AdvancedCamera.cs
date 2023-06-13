using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	internal class AdvancedCamera : Camera
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

		public AdvancedCamera(Vector lookFrom, Vector lookAt, Vector up, int FoV, double aspectRatio, double aperture)
		{
			this._origin = lookFrom;
			this.vectorW = lookFrom.Subtract(lookAt).getUnit();
			this.vectorU = up.Cross(this.vectorW).getUnit();
			this.vectorV = this.vectorW.Cross(this.vectorU);
			this._focalDistance = this._origin.Subtract(lookAt).Length();
			this._lensRadius = aperture / 2;
			double theta = (FoV * Math.PI) / 180;
			double heightHalf = Math.Tan(theta / 2);
			double widthHalf = aspectRatio * heightHalf;
			this._corner_lowerLeft = this._origin
				.Subtract(this.vectorU.Multiply(widthHalf * this._focalDistance))
				.Subtract(this.vectorV.Multiply(heightHalf * this._focalDistance))
				.Subtract(this.vectorW.Multiply(this._focalDistance));
			this._horizontal = this.vectorU.Multiply(2 * widthHalf * this._focalDistance);
			this._vertical = this.vectorV.Multiply(2 * heightHalf * this._focalDistance);
		}

		public override Ray getRay(double u, double v)
		{
			Vector horizontalPosition = this._horizontal.Multiply(u);
			Vector verticalPosition = this._vertical.Multiply(v);
			Vector random = Vector.getRandomInUnitModel().Multiply(this._lensRadius);
			Vector offset = this.vectorU
				.Multiply(random.X)
				.Add(this.vectorV.Multiply(random.Y));
			return new Ray(
				this._origin.Add(offset),
				this._corner_lowerLeft
					.Add(horizontalPosition.Add(verticalPosition))
					.Subtract(this._origin).Subtract(offset));

		}

	}
}