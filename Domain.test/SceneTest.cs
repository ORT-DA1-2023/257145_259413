using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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












    }
}
