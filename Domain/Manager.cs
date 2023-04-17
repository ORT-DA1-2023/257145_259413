using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Manager
    {

        private List<Client> clients;
        public Manager() 
        {
            this.clients = new List<Client>();
        }

        public Client logged { get; set; }

        public void add(Client client1)
        {
            foreach (Client client in clients)
            {
                if (client.name == client1.name)
                {
                    return;
                }
            }
            this.clients.Add(client1);
        }

        public Client logIn(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool Verify()
        {
            if(clients.Count == 0)
            {
                return false;
            }
            if(clients.Count == 1)
            {
                return true;
            }
            for(int i= 0; i < clients.Count; i++)
            {
                for(int j = i+1; j < clients.Count; j++)
                {
                    if (clients[i].name == clients[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
