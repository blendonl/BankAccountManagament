using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagamentLibrary.Services {
    public class PersoniServices : Services<Personi.Personi> {

        public PersoniServices() {
            Items = new List<Personi.Personi>();
        }
        public override bool Add(Personi.Personi item) {
          if (FindIndex(item.NrPersonal) == -1 ) {
              Items.Add(item);
              return true;
          }
          return false;  
        }

        public override bool Remove(int id) {
            int index = FindIndex(id);
            if (index != -1) {
                Items.Remove(Items[index]);
                return true;
            }
            return false;
        } 
        
        public int FindIndex(int clientId) {
            return Items.FindIndex(client => client.PersoniId.Equals(clientId));
        }
        
        private int FindIndex(string personalNumber) {
            return Items.FindIndex(client => client.NrPersonal == personalNumber);
        }

        public override Personi.Personi Get(int clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Items[index] : null;
        }

        public List<Client> GetAll() {
           List<Client> items = new List<Client>();

           foreach (var item in Items) {
               if (item.GetType().BaseType.Name.Equals(typeof(Client).Name)) {
                   items.Add((Client)item);
               }
           }

           return items;
       }
    }
}