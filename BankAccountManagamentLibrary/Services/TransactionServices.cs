using System;
using System.Collections.Generic;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankaccountManagamentLibrary.Services {
    
    public class TransactionServices {
        private List<Transaction> Transactions;

        public TransactionServices() {
            Transactions = new List<Transaction>();
        }
        public bool Add(Transaction transaction) {
           
            if((transaction.TransactionType.Equals(TransactionType.Deposit) 
                && transaction.Account.Deposit(transaction.Amount, transaction.Provision)) 
               || (transaction.TransactionType.Equals(TransactionType.Withdraw) 
                   && transaction.Account.WithDraw(transaction.Amount, transaction.Provision)) 
               || (transaction.TransactionType.Equals(TransactionType.Send) 
                   && (transaction.Account.WithDraw(transaction.Amount, transaction.Provision) 
                       && transaction.Account1.Deposit(transaction.Amount, transaction.Provision)))) {
                
                 BankServices.UpdateBalance(Convertor.ProvisionPercentage(transaction.Provision), transaction.TransactionType);
                 Transactions.Add(transaction);
                 return true;

            }
            return false;
        }
        
        public string GetAll() {
            string rez = "";

            foreach (var transaction in Transactions) {
                rez += transaction.ToString() + "\n";
            }

            return rez;
        }
        
         public string GetAll(Account account) {
                string rez = "";
        
                foreach (var transaction in Transactions) {
                    if(account.AccountNumber == transaction.Account.AccountNumber)
                        rez += transaction.ToString() + "\n";
                }
        
                return rez;
         } 
         public string GetAll(string clientId) {
             string rez = "";
        
             foreach (var transaction in Transactions) { 
                 if(clientId.Equals(transaction.Client.ClientId)) 
                     rez += transaction.ToString() + "\n";
             }
             return rez;
         }
    }
}
