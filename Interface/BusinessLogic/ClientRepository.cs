using Interface.DataAccess;
using Domain;
using Exceptions;
using Microsoft.Identity.Client;

namespace Interface.BusinessLogic
{
    public class ClientRepository
    {

        private ApplicationContext _dbContext;
        private SessionManager _sessionManager;


        public ClientRepository(ApplicationContext _dbContext, SessionManager sessionManager)
        {
            this._dbContext = _dbContext;
            this._sessionManager = sessionManager;
        }


		public List<Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public bool Exists(string name)
        {

            List<Client> clients = GetClients();
            foreach (Client client in clients)
            {
                if (client.MatchingUsername(name))
                {
                    throw new DuplicateUserException();
                }
            }
            return false;
        }


        public void add(Client client) { 
        
       
         
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        
        
        }

        public Client Find(int id)
        {
            return _dbContext.Clients.Find(id);
        }
    }
}
