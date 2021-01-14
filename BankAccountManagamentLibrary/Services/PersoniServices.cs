using Controller;
namespace BankAccountManagamentLibrary.Services {
    public class PersoniServices : Services<Personi.Personi> {
        public override bool Add(Personi.Personi item) {
          if (FindIndex(long.Parse(item.NrPersonal)) == -1 ) {
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
        
        public int FindIndex(string clientId) {
            return Items.FindIndex(client => client.PersoniId.Equals(clientId));
        }
        
        private int FindIndex(long personalNumber) {
            return Items.FindIndex(client => long.Parse(client.NrPersonal) == personalNumber);
        }

        public Personi.Personi Get(string clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Items[index] : null;
        }
    }
}