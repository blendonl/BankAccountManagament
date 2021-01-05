using System;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankaccountManagamentLibrary.Services {
    
    public class TransactionServices {

        public static bool Add(Account account, decimal amount, TransactionType transactionType, decimal intresRate) {
            Transaction transaction = new Transaction();
            transaction.AccountNumber = account.AccountNumber;
            transaction.Amount = amount;
            transaction.TransactionType = transactionType;
            if(transactionType.Equals(TransactionType.Deposit)) {
                account.Deposit(amount, intresRate);
            } else if(transactionType.Equals(TransactionType.Withdraw)) {
                account.WithDraw(amount, intresRate);
                
            }
            BankServices.UpdateBalance(intresRate, transactionType);
            Database.Transactions.Add(transaction);
            return true;
        }

        public static bool Add(Account account, Account account1, decimal amount, 
            decimal intresRate) {
            bool rez = false;
            Transaction transaction = new Transaction();
            transaction.AccountNumber = account.AccountNumber;
            transaction.Amount = amount;
            transaction.TransactionType = TransactionType.Send;
            try {
                    rez = true;
                    account.WithDraw(amount, intresRate);
                    account1.Deposit(amount, intresRate);
            }
            catch (NullReferenceException ex) {
                rez = false;
            }
            
            BankServices.UpdateBalance(Convertor.ProvisionPercentage(intresRate), TransactionType.Send);
            return rez;
        }

        public static bool Add(long accountNumber, TransactionType transactionType) {
            return false;
        }
        
     

    }
}
