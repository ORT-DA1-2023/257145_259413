using Exceptions;
using System.Drawing;
namespace Domain.test

{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ReturnsFalseIfNameisVoid()
        {
            Client client = new Client();
            bool result = true;
            string name = "";
            try
            {
                client.VerifyName(name);
            }
            catch(EmptyUserNameException ex)
            {

                result = false;
            }
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForShortName()
        {
            string name = "a1";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForLongName()
        {
            string name = "aaaaaaaaaaa1aaaaa2aaaaaaaaa";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsTrueIfAlphanumericName()
        {
            string name = "aa1";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNameHasAnySpaces()
        {
            string name = "a1 aaa";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfVoidPassword()
        {
            Client client = new Client();
            bool result = true;
            string password = "";
            try
            {
                client.VerifyPassword(password);
            }
            catch (EmptyUserNameException ex)
            {
                result = false;
            }
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForShortPassword()
        {
            string password = "a1";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForLongPassword()
        {
            string password = "aaaaaaaaaaa1aaaaa2aaaaaaaaa";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNotAlphanumericPassword()
        {
            string password = "aaaaaa";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNotUpperCasePassword()
        {
            string password = "a123bc";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void returnTrueIfDateGreatesThanSecondDate()
        {

            DateTime date = DateTime.Now;
            Client client = new Client();
            bool result = client.VerifyDate(date);
            Assert.IsTrue(result);





        }
        
        /*
        [TestMethod]
        public void returnFalseIfNoModelList()
        {
            Client client = new Client();
            bool result = client.VerifyListModels();
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void returnTrueIfOneModelList()
        {
            Client client = new Client();
            Model model = new Model();
            client.AddModel(model);
            bool result = client.VerifyListModels();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VerifyListModelReturnTrue()
        {

            Client client = new Client();
            Model model1 = new Model("model1");
            Model model2 = new Model("model2");
            Model model3 = new Model("model3");

            client.AddModel(model1);
            client.AddModel(model2);
            client.AddModel(model3);

            bool result1 = client.VerifyListModels();
            Assert.IsTrue(result1);

        }


        [TestMethod]
        public void returnFalseIfNoSceneList()
        {
            Client client = new Client();
            bool result = client.VerifyListScene();
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void returnTrueIfOneSceneList()
        {
            Client client = new Client();
            Scene scene = new Scene();
            client.AddScene(scene);
            bool result = client.VerifyListScene();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VerifyListSceneReturnTrue()
        {

            Client client = new Client();
            Scene scene1 = new Scene("scene1");
            Scene scene2 = new Scene("scene2");
            Scene scene3 = new Scene("scene3");

            client.AddScene(scene1);
            client.AddScene(scene2);
            client.AddScene(scene3);

            bool result1 = client.VerifyListScene();
            Assert.IsTrue(result1);

        }

        [TestMethod]
        public void returnFalseIfNomMaterialList()
        {
            Client client = new Client();
            bool result = client.VerifyMaterials();
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void returnTrueIfOneMaterialList()
        {
            Client client = new Client();
            Material mat = new Material();
            client.AddMaterial(mat);
            bool result = client.VerifyMaterials();
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void VerifyListMaterialReturnTrue()
        {

            Client client = new Client();
            Material mat1 = new Material("mat1",Color.Red);
            Material mat2 = new Material("mat2",Color.Blue);
            Material mat3 = new Material("mat3",Color.Black);

            client.AddMaterial(mat1);
            client.AddMaterial(mat2);
            client.AddMaterial(mat3);

            bool result1 = client.VerifyMaterials();
            Assert.IsTrue(result1);

        }


        [TestMethod]
        public void ReturnsTrueIfModelIsLinked()
        {
            Client client = new Client();
            Model model = new Model();
            PositionedModel positioned = new PositionedModel(model, new Coordinate());
            Scene scene = new Scene("");
            scene.addPositionedModel(positioned);
            client.AddModel(model);
            client.AddScene(scene);
            Assert.IsTrue(client.ModelIsLinked(model));
        }*/

    }
}