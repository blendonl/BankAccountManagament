using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagamentLibrary.Services {
    public static class AccountServices {

        public static Account Add(Client client, AccountType accountType, decimal initialBalance) {
            Account account = new Account();
            account.AccountType = accountType;
            account.Balance = initialBalance;
            account.Active = true;
            account.Client = client;
            Database.Accounts.Add(account);
            long accountNumber = -1;
            do {
                accountNumber = NumberGenerator.GenerateAccountNumber();
            } while (Get(accountNumber) != null);

            account.AccountNumber = accountNumber;
            return account;
        }

        public static bool Remove( long accountNumber) {
            int index = Database.Accounts.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Database.Accounts.Remove(Database.Accounts[index]);
            else
                return false;
        }

        public static Account Get(long accountNumber) {
            int index = Database.Accounts.FindIndex(account => account.AccountNumber.Equals(accountNumber));
            if (index != -1)
                return Database.Accounts[index];
            else
                return null;
        }
        

      
             
    }
}
