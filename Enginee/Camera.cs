using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        private Vector _origin;
        private Vector _corner_lowerLeft;
        private Vector _horizontal;
        private Vector _vertical;

        public Camera(Vector lookFrom, Vector lookAt, Vector up, int FoV, double aspectRatio)
        {
            double theta = FoV * Math.PI / 180;
            double heightHalf = Math.Tan(theta / 2);
            double widthHalf = aspectRatio * heightHalf;
            this._origin = lookFrom;
            Vector w = lookFrom.Substract(lookAt).getUnit();
            Vector u = up.Cross(w).getUnit();
            Vector v = w.Cross(u);
            this._corner_lowerLeft = this._origin.Substract(u.Multiply(widthHalf)).Substract(v.Multiply(heightHalf)).Substract(w);
            this._horizontal = u.Multiply(2 * widthHalf);
            this._vertical = v.Multiply(2 * heightHalf);
        }

        public Ray getRay(double u, double v)
        {
            Vector horizontalPosition = this._horizontal.Multiply(u);
            Vector verticalPosition = this._vertical.Multiply(v);
            return new Ray(this._origin, this._corner_lowerLeft.Add(horizontalPosition.Add(verticalPosition)).Substract(this._origin));

        }
    }
}
