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
        public void ReturnsTrueIfNotDecimalNUmber()
        {
            float x = 1;
            float y = 1;
            float z = 1;
            Coordinate coordinate = new Coordinate();
            bool result = coordinate.VerifyCoordinate(x,y,z);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void toString()
        {
           PositionedModel positionedModel1= new PositionedModel();
            positionedModel1.model = new Model("modelName");
            positionedModel1.position = new Coordinate(2, 5, 4);

            string result = positionedModel1.ToString();
            Assert.AreEqual("Model: " + positionedModel1.model.name + "  " +
                  "Position: " + positionedModel1.position, result);
        }


        [TestMethod]
        public void constructorPositionedModel()
        {
          
            Model model = new Model("model1");
            Coordinate position = new Coordinate(1, 1, 1);
            PositionedModel positionedModel = new PositionedModel(model,position);
            Assert.AreEqual(model, positionedModel.model);
            Assert.AreEqual(position, positionedModel.position);

        }





    }
}
