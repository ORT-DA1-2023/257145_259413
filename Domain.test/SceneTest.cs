using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.test
{
    [TestClass]
    public class SceneTest
    {


        [TestMethod]
        public void ReturnsFalseIfNameisVoid()
        {
            string name = "";
            Scene scene = new Scene();
            bool result = scene.VerifyName(name);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void returnFalseIfHasAnySpace()
        {

            string name = " aa2 ";
            Scene scene = new Scene();
            bool result = scene.VerifyName(name);
            Assert.IsFalse(result);

        }



        /*[TestMethod]
        public void returnTrueIfUnique()
        {


            Client client1 = new Client();
            Scene scene1 = new Scene("fig1");
            Scene scene2 = new Scene("fig1");

            client1.AddScene(scene1);
            client1.AddScene(scene2);
            bool result = client1.VerifyListScene();
            Assert.IsTrue(result);

        }*/

        [TestMethod]
        public void returnTrueIfDateGreatesThanSecondDate()
        {

            DateTime date = DateTime.Now;
            Scene scene = new Scene();
            bool result = scene.VerifyDate(date);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnsTrueIfPositionedModelListIsCreated()
        {
            Scene scene = new Scene();
            bool result = scene.VerifyPositionedModels();
            Assert.IsTrue(result);
        }

        /*[TestMethod]
        public void ReturnsTrueIfLastModifiedDateIsModifiedWhenModelAdded()
        {
            PositionedModel positionedModel = new PositionedModel(new Model("test"),new Coordinate());
            Scene scene = new Scene();
            DateTime date = scene.lastModified;
            scene.addPositionedModel(positionedModel);
            Assert.IsTrue(DateTime.Compare(scene.lastModified, date) >=1);
        }

        [TestMethod]
        public void ReturnsTrueIfLastModifiedDateIsModifiedWhenModelDeleted()
        {
            PositionedModel positionedModel = new PositionedModel(new Model("test"), new Coordinate());
            PositionedModel positionedModel2 = new PositionedModel(new Model("test"), new Coordinate());
            PositionedModel positionedModel3 = new PositionedModel(new Model("test"), new Coordinate());
            Scene scene = new Scene();
            scene.addPositionedModel(positionedModel);
            scene.addPositionedModel(positionedModel2);
            scene.addPositionedModel(positionedModel3);
            DateTime date = scene.lastModified;
            scene.deletePositionedModel(positionedModel);
            Assert.IsTrue(DateTime.Compare(scene.lastModified, date) >= 1);
        }

        [TestMethod]
        public void ReturnsTrueIfLastrenderedDateIsModifiedWhenSceneAdded()
        {
            Scene scene = new Scene();
            DateTime date = scene.lastRendered;
            scene.Render();
            Assert.IsTrue(DateTime.Compare(scene.lastRendered, date) >= 1);


        }


        [TestMethod]
        public void ReturnsFalseIfNotDecimalNUmber()
        {
            float x = 1;
            float y = 1;
            float z = 1;
            Scene scene = new Scene();
            bool result = scene.VerifyCoordinate(x, y, z);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ReturnsFalseIfFoVUnder1()
        {
            Scene scene = new Scene();
            int fov = -2;
            bool result;
            try
            {
                    result = scene.VerifyFoV(fov);
            }
            catch(FovOutOfBoundException)
            {
                result=false;
            }
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfFoVAbove160()
        {
            Scene scene = new Scene();
            int fov = 165;
			bool result;
			try
			{
				result = scene.VerifyFoV(fov);
			}
			catch (FovOutOfBoundException)
			{
				result = false;
			}
			Assert.IsFalse(result);
		}

        [TestMethod]
        public void ReturnsTrueIfFoVDefaultValueIs30()
        {
            Scene scene = new Scene();
            int fov = 30;
            Assert.AreEqual(scene.FieldOfVision, fov);
        }



        [TestMethod]
        public void ReturnTrueGetPositionedModels()
        {
            Scene scene = new Scene();
            PositionedModel positionedModel = new PositionedModel(new Model("test"), new Coordinate());
            PositionedModel positionedModel2 = new PositionedModel(new Model("test"), new Coordinate());

            scene.addPositionedModel(positionedModel);
            scene.addPositionedModel(positionedModel2);
            List<PositionedModel> result = scene.GetPositionedModels().ToList();

            Assert.IsTrue(result.Contains(positionedModel));

        }


        [TestMethod]
        public void ReturnTrueModelIsPositioned()
        {
            Scene scene = new Scene();
            Model model = new Model();
            Coordinate coordinate = new Coordinate(1,1,1);
            PositionedModel positionedModel = new PositionedModel(model, coordinate );

            scene.addPositionedModel(positionedModel);
            bool result = scene.ModelIsPositioned(model);
            Assert.IsTrue(result);


        }*/

       

    }
}
