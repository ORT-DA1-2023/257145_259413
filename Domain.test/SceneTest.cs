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



        [TestMethod]
        public void returnTrueIfUnique()
        {


            Client client1 = new Client();
            Scene scene1 = new Scene("fig1");
            Scene scene2 = new Scene("fig1");

            client1.addScenes(scene1);
            client1.addScenes(scene2);
            bool result = client1.VerifyListScene();
            Assert.IsTrue(result);

        }

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

        [TestMethod]
        public void ReturnsTrueIfLastModifiedDateIsModifiedWhenModelAdded()
        {
            PositionedModel positionedModel = new PositionedModel();
            Scene scene = new Scene();
            DateTime date = scene._lastModified;
            scene.addPositionedModel(positionedModel);
            Assert.IsTrue(DateTime.Compare(scene._lastModified, date) >=1);
        }

        [TestMethod]
        public void ReturnsTrueIfLastModifiedDateIsModifiedWhenModelDeleted()
        {
            PositionedModel positionedModel = new PositionedModel();
            PositionedModel positionedModel2 = new PositionedModel();
            PositionedModel positionedModel3 = new PositionedModel();
            Scene scene = new Scene();
            scene.addPositionedModel(positionedModel);
            scene.addPositionedModel(positionedModel2);
            scene.addPositionedModel(positionedModel3);
            DateTime date = scene._lastModified;
            scene.deletePositionedModel(1);
            Assert.IsTrue(DateTime.Compare(scene._lastModified, date) >= 1);
        }

        [TestMethod]
        public void ReturnsTrueIfLastrenderedDateIsModifiedWhenSceneAdded()
        {
            Scene scene = new Scene();
            DateTime date = scene._lastRendered;
            scene.Render();
            Assert.IsTrue(DateTime.Compare(scene._lastRendered, date) >= 1);


        }


        [TestMethod]
        public void ReturnsFalseIfNotDecimalNUmber()
        {
            float x = 1;
            float y = 1;
            float z = 1;
            Scene scene = new Scene();
            bool result = scene.VerifyCoordinate(x, y, z);
            Assert.IsFalse(result);

        }
    }
}
