using Interface.BusinessLogic;
using Domain;
using Exceptions;
using NuGet.Frameworks;
using System.Drawing;
using Interface.DataAccess;

namespace BusinessLogic.test
{
	[TestClass]
	public class ClientsTest
	{
		private ClientRepository clientRepository;
		private SessionManager sessionManager;

		[TestInitialize]
		public void Initialize()
		{
			clientRepository = new ClientRepository(TestContextFactory.CreateContext(), sessionManager);
		}

		[TestMethod]
		public void ReturnsTrueIfClientIsCreated()
		{
			Client client = new Client()
			{
				name = "Pedro",
				password = "MejorObl1gatorio"
			};
			clientRepository.add(client);
			bool result;
			try
			{
				result = clientRepository.Exists(client.name);
			}
			catch (DuplicateUserException)
			{
				result = true;
			}
			Assert.IsTrue(result);
		}

		public void ReturnsFalseIfClientDoesntExist()
		{
			bool result = clientRepository.Exists("NoExisteUsuario");
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnsTrueIfClientIsFound()
		{
			Client client = new Client()
			{
				name = "Error404",
				password = "MejorObl1gatorio"
			};
			clientRepository.add(client);
			Client result = clientRepository.Find(client.Id);
			Assert.AreEqual(client, result);
		}

		[TestMethod]
		public void ReturnsTrueIfClientsAreAddedCorrectly()
		{
			Client client = new Client()
			{
				name = "Pedro",
				password = "Pascal1"
			};
			clientRepository.add(client);
			List<Client> clients = clientRepository.GetClients();
			Assert.IsTrue(clients.Count > 0);
		}

		/*[TestMethod]
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
        public void ReturnsTrueIfUsersAreUnique()
        {
            Client client = new Client("Pedro1", "Contra1");
            Client repeated = new Client("Pedro1", "Contra1");
            Manager manager = new Manager();
            manager.add(client);
            manager.add(repeated);
            Assert.IsTrue(manager.clients.Count == 1);
        }


        [TestMethod]
        public void ReturnNullIfUserNotLoggedIn()
        {
            string name = "Pedro";
            string password = "MejorObl1gatorio";
            Manager system = new Manager();
            Client loggedIn = new Client("Pedro", "MejorObl1gatorio");
            system.add(loggedIn);
            string name2 = "Lucas";
            Client actualLogged = system.logIn(name2, password);
            Assert.IsNull(actualLogged);



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
        [TestMethod]
        public void ReturnTrueIfClientCanDeleteMaterial()
        {

            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Material material = new Material();
            Material material1 = new Material();
            manager.addMaterial(material);
            manager.addMaterial(material1);
            manager.DeleteMaterial(material);
            Assert.IsTrue(!client.getMaterials().Contains(material));

        }

        [TestMethod]
        public void ReturnTrueIfClientCanCreateANewModel()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Model model = new Model();
            manager.addModel(model);
            Assert.IsTrue(client.getModels().Contains(model));
        }

        [TestMethod]
        public void ReturnTrueIfClientCanDeleteModel()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Model model = new Model();
            Model model1 = new Model();
            manager.addModel(model);
            manager.addModel(model1);
            manager.DeleteModel(model);
            Assert.IsTrue(!client.getModels().Contains(model));
        }


        [TestMethod]
        public void ReturnTrueIfClienteCanCreateaNewScene()
        {

            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Scene scene = new Scene();
            manager.addScene(scene);
            Assert.IsTrue(client.getScenes().Contains(scene));
        }

        [TestMethod]
        public void ReturnTrueIfClientCanDeleteScene()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Scene scene = new Scene();
            Scene scene1 = new Scene();
            manager.addScene(scene);
            manager.addScene(scene1);
            manager.DeleteScene(scene);
            Assert.IsTrue(!client.getScenes().Contains(scene));
        }


        [TestMethod]
        public void ReturnTrueGetScenebyName()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Scene scene = new Scene("scene1");
            manager.addScene(scene);
            Assert.IsTrue(manager.GetScenebyName("scene1").Equals(scene));
        }

        [TestMethod]
        public void AreEqualFindMatchingMaterial()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Material mat1 = new Material("ma1", Color.Red);
            Material mat2 = new Material("ma2", Color.Red);
            client.AddMaterial(mat1);
            client.AddMaterial(mat2);
            Assert.AreEqual(mat1, manager.MatchingMaterial("ma1"));
        }



        [TestMethod]
        public void AreEqualNotFindMatchingMaterial()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Material mat2 = new Material("ma2", Color.Red);
            client.AddMaterial(mat2);
            Material result = manager.MatchingMaterial("mat1");
            Material result2 = new Material();
            Assert.AreEqual(result2.name, result.name);

        }

       
        [TestMethod]
        public void AreEqualFindMatchingFigure()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Figure fig1 = new Figure("fig1", 1);
            Figure fig2 = new Figure ("fig2", 2);
            client.AddFigure(fig1);
            client.AddFigure(fig2);
            Assert.AreEqual(fig1, manager.MatchingFigure("fig1"));
        }


        [TestMethod]
        public void AreEqualNotFindMatchingFigure()
        {
            Manager manager = new Manager();
            Client client = new Client();
            manager.logged = client;
            Figure fig2 = new Figure("fig1", 1);
            client.AddFigure(fig2);
            Figure result = manager.MatchingFigure("fig2");
            Figure result2 = new Figure();
            Assert.AreEqual(result2.name, result.name);
        }

        [TestMethod]
        public void ReturnTrueIfExists()
        {

            Manager manager = new Manager();
            Client client = new Client("Juan","JuanPas2");
            manager.logged = client;

            manager.add(client);

            bool result = false;
            try
            {
				result = manager.Exists(client.name);
			}
            catch(DuplicateUserException ex)
            {
                result = true;
            }
            
            Assert.IsTrue(result);



        }

        [TestMethod]
        public void ReturnFalseIfNotExists()
        {

            Manager manager = new Manager();
            Client client = new Client("Juan", "JuanPas2");
            manager.logged = client;

            manager.add(client);
            bool result = manager.Exists("Tomas");
            Assert.IsFalse(result);



        }


        [TestMethod]
        public void ReturnsTrueIfWrongUserCannotSignUp()
        {
            Manager manager = new Manager();
            Client signedIn = manager.SignUp("a", "a");
            Assert.IsTrue(signedIn.name == "");
        }*/
	}
}