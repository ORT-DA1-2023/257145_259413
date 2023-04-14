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
          
        }


        public Coordinate(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public bool VerifyCoordinate(float x, float y, float z)
        {
            return false;
        }
    }
}
