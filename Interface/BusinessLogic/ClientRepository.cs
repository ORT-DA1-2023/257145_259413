using Interface.DataAccess;
using Domain;
using Exceptions;
using Microsoft.Identity.Client;

namespace Interface.BusinessLogic
{
    public class ClientRepository
    {

        private ApplicationContext _dbContext;


        public ClientRepository(ApplicationContext _dbContext)
        {
            this._dbContext = _dbContext;
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








    }
}
