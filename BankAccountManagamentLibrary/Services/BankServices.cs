
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.TransactionModel;


namespace BankAccountManagamentLibrary.Services {
    public static class BankServices {

        public static void UpdateBalance(ITransaction transaction) {
            if (transaction.GetType().Name.Equals("Deposit") || transaction.GetType().Name.Equals("Withdraw")) {
                Bank.BankBalance += transaction.Provision;
            } else if (transaction.GetType().Name.Equals("Withdraw")) {
                Bank.BankBalance -= transaction.Provision;
            }
        }
        
        public static decimal GetALlClientsMoney() {
            decimal all = 0;
            // foreach (var account in Database.Accounts) {
            //     all += account.Balance;
            // }
            return all;
        }

       
        
        
    }
}