using BusinessLogic;
using Domain;

namespace BusinessLogic.test
{
    [TestClass]
    public class SystemTest
    {
        [TestMethod]
        public void ReturnsTrueIfUniqueClients()
        {
            Manager system = new Manager();
            Client client1 = new Client("juan2", "myPassw1");
            Client client2 = new Client("Juan2", "myPassw2");
            Client client3 = new Client("Juan2", "myPassw3");
            system.add(client1);
            system.add(client2);
            system.add(client3);
            bool result = system.Verify();
            Assert.IsTrue(result);
        }
    

        [TestMethod]
        public void ReturnsTrueIfUserLoggedIn()
        {
            string name = "Pedro";
            string password = "MejorObl1gatorio";
            Manager system = new Manager();
            Client loggedIn = new Client("Pedro", "MejorObl1gatorio");
            system.add(loggedIn);
            Client actualLogged = system.logIn(name, password);
            Assert.IsTrue(system.logged.Equals(actualLogged));
        }

        [TestMethod]
        public void ReturnsTrueIfClientCanSignUp()
        {
            string name = "Marco5";
            string password = "NoPued3Ser";
            Manager system = new Manager();
            Client result = system.SignUp(name, password);
            Assert.IsTrue(result.MatchingUsername(name) && result.MatchingPassword(password));
        }

        [TestMethod]
        public void ReturnsTrueIfClientCanCreateANewFigure()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Figure figure = new Figure();
            manager.addFigure(figure);
            Assert.IsTrue(client.getFigures().Contains(figure));
        }

        [TestMethod]
        public void ReturnsTrueIfClientCanDeleteFigure()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Figure figure = new Figure();
            Figure figure1 = new Figure();
            manager.addFigure(figure);
            manager.addFigure(figure1);
            manager.DeleteFigure(figure);
            Assert.IsTrue(!client.getFigures().Contains(figure));
            

        }


        [TestMethod]
        public void ReturnTrueIfClientCanCreateANewMaterial()
        {

            Manager manager = new Manager();
            Client client = new Client();
            manager.logged= client;
            Material material = new Material();
            manager.addMaterial(material);
            Assert.IsTrue(client.getMaterials().Contains(material));

        }

        


    }
}