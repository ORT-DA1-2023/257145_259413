using Interface.DataAccess;
using Domain;
using Exceptions;

namespace Interface.BusinessLogic
{
    public class AuthLogic
    {


        private SessionManager sessionManager;
        private ApplicationContext _dbContext;
        private ClientRepository clientRepository;



        public AuthLogic(SessionManager sessionManager, ApplicationContext applicationContext)
        {
            this.sessionManager = sessionManager;
            this.clientRepository = new ClientRepository(applicationContext, sessionManager);
        }

        public void add(Client client1)
        {

            List<Client> clients = clientRepository.GetClients();

            foreach (Client client in clients)
            {
                if (client.MatchingUsername(client1.name))
                {
                    throw new DuplicateUserException();
                   
                }
            }
          
            clientRepository.add(client1);
        }

        public Client LogIn(string name, string password)
        {

            List<Client> clients = clientRepository.GetClients();

            foreach (Client client in clients)
            {
                if (client.MatchingUsername(name) && client.MatchingPassword(password))
                {
                    sessionManager.CurrentUser = client;
                    return client;
                }
            }
            return null;
        }

        public Client SignUp(string name, string password)
        {
            Client client = new Client();
            if (!client.VerifyName(name) || !client.VerifyPassword(password) || clientRepository.Exists(name))
            {
               
                return client;
            }

            client.name = name;
            client.password = password;
            clientRepository.add(client);
            sessionManager.CurrentUser = client;    
            return client;
        }

        public Client GetCurrentUser()
        {
            return sessionManager.CurrentUser;
        }



    }
}
