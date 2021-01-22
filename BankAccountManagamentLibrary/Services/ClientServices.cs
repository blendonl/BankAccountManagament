using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagamentLibrary.Services {
    public class ClientServices : IService<Client> {
        
        public List<Client> Items { get; }

        public ClientServices() {
            Items = new List<Client>();
        }


        public bool Add(Client client) {
            if (FindIndex(long.Parse(client.NrPersonal)) == -1 ) {
                Items.Add(client);
                return true;
            }
            return false;
        }


       

        public bool Remove(int clientId) {
            int index = FindIndex(clientId);
            if (index != -1) {
                Items.Remove(Items[index]);
                return true;
            }
            return false;
        }

        public int FindIndex(int clientId) {
            return Items.FindIndex(client => client.PersoniId.Equals(clientId));
        }

        private int FindIndex(long personalNumber) {
            return Items.FindIndex(client => long.Parse(client.NrPersonal) == personalNumber);
        }

        public Client Get(int clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Items[index] : null;
        }
         public List<Client> GetAll() { 
            List<Client> items = new List<Client>();
        
            foreach (var item in Items) {
                items.Add(item);
            }
            return items;
        } 
    }
}
