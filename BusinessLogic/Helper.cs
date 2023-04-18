using Domain;

namespace BusinessLogic
{
    public class Helper
    {

        public Manager manager { get; set; }

        public Helper()
        {
            Manager manager = new Manager();
        }

        public void addClient(Client client)
        {
            manager.add(client);
        }
    }

}