using System.Collections.Generic;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using Controller.Models;

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

            foreach (Account account in (List<Account>) Container.GetDependency(typeof(AccountServices))
                .InvokeMethod("GetAll") ?? new List<Account>()) {
                all += account.Balance;
            }

            return all;
        }

       
        
        
    }
}