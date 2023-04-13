using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.test
{
    [TestClass]
    public class ModelTest
    {

        [TestMethod]
        public void ReturnsFalseIfNameisVoid()
        {
            string name = "";
            Model model = new Model();
            bool result = model.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void returnFalseIfHasAnySpace()
        {

            string name = " aa2 ";
            Model model = new Model();
            bool result = model.VerifyName(name);
            Assert.IsFalse(result);

        }



        [TestMethod]
        public void returnTrueIfUnique()
        {


            Client client1 = new Client();
            Model model1 = new Model("model1");
            Model model2 = new Model("model1");
            client1.addModel(model1);
            client1.addModel(model2);
            bool result = client1.VerifyListModels();
            Assert.IsTrue(result);

        }








    }
}
