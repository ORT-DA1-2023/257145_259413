namespace Domain.test
{
    [TestClass]
    public class SystemTest
    {
        [TestMethod]
        public void ReturnsTrueIfUniqueClients()
        {
            System system = new System();
            Client client1 = new Client("juan2", "myPassw1");
            Client client2 = new Client("Juan2", "myPassw2");
            Client client3 = new Client("Juan2", "myPassw3");
            system.add(client1);
            system.add(client2);
            system.add(client3);
            bool result = system.Verify();
            Assert.IsTrue(result);
        }
    }
}