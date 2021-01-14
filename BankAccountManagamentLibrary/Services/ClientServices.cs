using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagamentLibrary.Services {
    public class ClientServices {
        private List<Client> Clients;

        public ClientServices() {
            Clients = new List<Client>();
        }

        public bool Add(Client client) {
            if (FindIndex(long.Parse(client.NrPersonal)) == -1 ) {
                Clients.Add(client);
                return true;
            }
            return false;
        }


       

        public bool Remove(int clientId) {
            int index = FindIndex(clientId);
            if (index != -1) {
                Clients.Remove(Clients[index]);
                return true;
            }
            return false;
        }

        public int FindIndex(int clientId) {
            return Clients.FindIndex(client => client.PersoniId.Equals(clientId));
        }

        private int FindIndex(long personalNumber) {
            return Clients.FindIndex(client => long.Parse(client.NrPersonal) == personalNumber);
        }

        public Client Get(int clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Clients[index] : null;
        }
         public List<Client> GetAll() { 
            List<Client> items = new List<Client>();
        
            foreach (var item in Clients) {
                items.Add(item);
            }
            return items;
        } 
    }
}
