using Interface.DataAccess;
using Domain;
using Exceptions;

namespace Interface.BusinessLogic
{
    public class AuthLogic
    {


        private SessionManager _sessionManager;
        private ApplicationContext _dbContext;
        private ClientRepository _clientRepository;



        public AuthLogic(SessionManager sessionManager, ApplicationContext applicationContext)
        {
            this._sessionManager = sessionManager;
            this._clientRepository = new ClientRepository(applicationContext, sessionManager);
        }

        public void add(Client client1)
        {

            List<Client> clients = _clientRepository.GetClients();

            foreach (Client client in clients)
            {
                if (client.MatchingUsername(client1.name))
                {
                    throw new DuplicateUserException();
                   
                }
            }
          
            _clientRepository.add(client1);
        }

        public Client LogIn(string name, string password)
        {

            List<Client> clients = _clientRepository.GetClients();

            foreach (Client client in clients)
            {
                if (client.MatchingUsername(name) && client.MatchingPassword(password))
                {
                    _sessionManager.CurrentUser = client;
                    return client;
                }
            }
            return null;
        }

        public Client SignUp(string name, string password)
        {
            Client client = new Client();
            if (!client.VerifyName(name) || !client.VerifyPassword(password) || _clientRepository.Exists(name))
            {
               
                return client;
            }

            client.name = name;
            client.password = password;
            _clientRepository.add(client);
            _sessionManager.CurrentUser = client;    
            return client;
        }

        public Client GetCurrentUser()
        {
            return _sessionManager.CurrentUser;
        }



    }
}
