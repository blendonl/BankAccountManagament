using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Services {
    public class AccountServices {

        private List<Account> Accounts;

        public AccountServices() {
            Accounts = new List<Account>();
        }
        
        public bool Add(Account account) {
            Accounts.Add(account);

            return true;
        }

        public bool Remove(long accountNumber) {
            int index = Accounts.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Accounts.Remove(Accounts[index]);
            else
                return false;
        }

        public Account Get(long accountNumber) {
            int index = Accounts.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Accounts[index];
            else
                return null;
        }
        
         public List<Account> GetAll() { 
            List<Account> items = new List<Account>();
        
            foreach (var item in Accounts) {
                items.Add(item);
            }
            return items;
         }   
        public List<Account> GetAll(string clientId) {
            List<Account> accounts = new List<Account>();
     
             foreach (var account in Accounts) {
                 if(account.Client.ClientId.Equals(clientId))
                    accounts.Add(account);
             }
 
             return accounts;
        }
        
        public List<Account> GetAll(Client client) {
            List<Account> accounts = new List<Account>();
     
             foreach (var account in Accounts) {
                 if(account.Client.ClientId.Equals(client.ClientId))
                    accounts.Add(account);
             }
 
             return accounts; 
        }
    }
}
