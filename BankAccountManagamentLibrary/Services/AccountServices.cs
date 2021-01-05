using System.Collections.Generic;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;

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

        public bool Remove( long accountNumber) {
            int index = Accounts.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Accounts.Remove(Database.Accounts[index]);
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
        
        
        public string GetAll() {
            string rez = "";

            foreach (var account in Accounts) {
                rez += account.ToString() + "\n";
            }

            return rez;
        } 
        public string GetAll(string clinetId) {
             string rez = "";
     
             foreach (var account in Accounts) {
                 if(account.Client.ClientId.Equals(clinetId))
                    rez += account.ToString() + "\n";
             }
 
             return rez;
        }
    }
}
