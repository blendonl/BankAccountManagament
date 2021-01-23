using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Services {
    public class AccountServices : IService<Account> {
        public List<Account> Items { get; }
        public AccountServices() {
            Items = new List<Account>();
        }
        public bool Add(Account account) {
            if (Get(account.AccountNumber) == null) {
                Items.Add(account);
                return true;
            }
            return false;
        }
        public bool Remove(long accountNumber) {
            int index = Items.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Items.Remove(Items[index]);
            else
                return false;
        }
        public Account Get(long accountNumber) {
            int index = Items.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Items[index];
            else
                return null;
        }
        public List<Account> GetAll() { 
            List<Account> items = new List<Account>();
        
            foreach (var item in Items) {
                items.Add(item);
            }
            return items;
         }   
        public List<Account> GetAll(int clientId) {
            List<Account> accounts = new List<Account>();
     
             foreach (var account in Items) {
                 if(account.Client.PersoniId.Equals(clientId))
                    accounts.Add(account);
             }
 
             return accounts;
        }
        public List<Account> GetAll(Client client) {
            List<Account> accounts = new List<Account>();
     
             foreach (var account in Items) {
                 if(account.Client.PersoniId.Equals(client.PersoniId))
                    accounts.Add(account);
             }
 
             return accounts; 
        }
    }
}
