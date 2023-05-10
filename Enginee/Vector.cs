namespace Engine
{
    public class Vector
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        public double Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public double Z
        {
            get { return this._z; }
            set { this._z = value; }
        }

        public double Red()
        {
            return Math.Abs(Math.Round(this._x*255));
        }

        public double Green()
        {
            return Math.Abs(Math.Round(this._y*255));
        }

        public double Blue()
        {
            return Math.Abs(Math.Round(this._z*255));
        }

        public Vector Add(Vector v)
        {
            return new Vector(this._x + v._x, this._y + v._y, this._z + v._z);
        }

        public Vector Substract(Vector v)
        {
            return new Vector(this._x - v._x, this._y - v._y, this._z - v._z);
        }

        public Vector Multiply(double i)
        {
            return new Vector(this._x * i, this._y * i, this._z * i);
        }

        public Vector Divide(double i)
        {
            return new Vector(this._x / i, this._y / i, this._z / i);
        }

        public void AddTo(Vector v)
        {
            this._x += v._x;
            this._y += v._y;
            this._z += v._z;
        }

        public void SubstractFrom(Vector v)
        {
            this._x -= v._x;
            this._y -= v._y;
            this._z -= v._z;
        }

        public void ScaleUpBy(int i)
        {
            this._x *= i;
            this._y *= i;
            this._z *= i;
        }

        public void ScaleDownBy(int i)
        {
            this._x /= i;
            this._y /= i;
            this._z /= i;
        }

        public double SquaredLength()
        {
            return (this._x * this._x) + (this._y * this._y) + (this._z * this._z);
        }

        public double Length()
        {
            return Math.Sqrt(this.SquaredLength());
        }

        public Vector getUnit()
        {
            return this.Divide(this.Length());
        }

        public double Dot(Vector v)
        {
            return (this._x * v._x) + (this._y * v._y) + (this._z * v._z);
        }

        public Vector Cross(Vector v)
        {
            double x = this._y * v._z - this._z * v._y;
            double y = this._z * v._x - this._x * v._z;
            double z = this._x * v._y - this._y * v._x;
            return new Vector(x, y, z);
        }
    }
}