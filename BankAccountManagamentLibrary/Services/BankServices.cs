using System.Transactions;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.TransactionModel;
using Transaction = System.Transactions.Transaction;

namespace BankAccountManagamentLibrary.Services {
    public static class BankServices {


        public static void UpdateBalance(decimal amount, TransactionType transactionType) {
            if (transactionType == TransactionType.Deposit) {
                Bank.BankBalance += amount;
            }
            else if (transactionType == TransactionType.Withdraw) {
                Bank.BankBalance += amount;
            } else if (transactionType == TransactionType.Loan) {
                Bank.BankBalance -= amount;
            }
        }
        
        public static decimal GetALlClientsMoney() {
            decimal all = 0;
            foreach (var account in Database.Accounts) {
                all += account.Balance;
            }
            return all;
        }

       
        
        
    }
}