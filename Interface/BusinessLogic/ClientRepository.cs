using Interface.DataAccess;
using Domain;
using Exceptions;
using Microsoft.Identity.Client;

namespace Interface.BusinessLogic
{
    public class ClientRepository
    {

        private ApplicationContext _dbContext;
        private SessionManager sessionManager;


        public ClientRepository(ApplicationContext _dbContext, SessionManager sessionManager)
        {
            this._dbContext = _dbContext;
            this.sessionManager = sessionManager;
        }


		public List<Client> GetClients()
        {
            return _dbContext.clients.ToList();
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
        
       
         
            _dbContext.clients.Add(client);
            _dbContext.SaveChanges();
        
        
        }

        public Client Find(int id)
        {
            return _dbContext.clients.Find(id);
        }
    }
}
