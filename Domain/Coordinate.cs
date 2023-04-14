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
            
            return VerifyCoordinateValues(x) && VerifyCoordinateValues(y) && VerifyCoordinateValues(z);

        }

       
        public bool VerifyCoordinateValues (float coordinate)
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




    }
}
