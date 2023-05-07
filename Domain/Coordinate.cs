using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Coordinate
    {

        public float x;
        public float y;
        public float z;

        public Coordinate()
        {
            this.x =0;
            this.y = 0;
            this.z = 0;
        }

        public Coordinate(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

		public bool VerifyCoordinate(float x, float y, float z)
        {
            return VerifyCoordinateValues(x) && VerifyCoordinateValues(y) && VerifyCoordinateValues(z);
        }

        // HACER REFACTORING
		public bool VerifyCoordinateValues(Object coordinate)
		{
			return coordinate.GetType() == typeof(float) ? (float)coordinate > 0 : false;
		}



		/*public bool VerifyCoordinateValues (float coordinate)
        {
            if (coordinate.ToString().Contains("."))
            {
                String radiusLetter = coordinate.ToString();
                for (int i = 0; i < radiusLetter.Length - 1; i++)
                {
                    if (radiusLetter[i].Equals("."))
                    {
                        if (char.IsDigit(radiusLetter[i + 1]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        */

		public override string ToString()
		{
			return "x: " + this.x + " y: " + this.y + " z: " + this.z;
		}
    }
}
