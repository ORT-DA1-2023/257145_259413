using Domain;

namespace BusinessLogic.test;

[TestClass]
public class HelperTest
{
    [TestMethod]
    public void ReturnsTrueIfUserLoggedIn()
    {
        string name = "Pedro";
        string password = "MejorObl1Gatorio";
        Manager system = new Manager();
        Client loggedIn = new Client("Pedro","MejorObl1gatorio");
        system.add(loggedIn);
        Client actualLogged = system.logIn(name,password);
        Assert.IsTrue(system.logged.Equals(actualLogged));
        

    }
}