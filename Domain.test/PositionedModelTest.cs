using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.test
{
    [TestClass]
    public class PositionedModelTest
    {


        [TestMethod]
        public void ReturnsFalseIfNotDecimalNUmber()
        {
            float x = 1;
            float y = 1;
            float z = 1;
            Coordinate coordinate = new Coordinate();
            bool result = coordinate.VerifyCoordinate(x,y,z);
            Assert.IsFalse(result);

        }








    }
}
