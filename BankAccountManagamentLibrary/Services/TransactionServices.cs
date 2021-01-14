using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
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
        
        public List<Transaction> GetAll() {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var transaction in Transactions) {
                transactions.Add(transaction);
            }

            return transactions;
        }
          public List<Transaction> GetAll(Account account) {
                List<Transaction> transactions = new List<Transaction>();
                foreach (var transaction in Transactions) {
                    if(transaction.Account.AccountNumber == account.AccountNumber)
                        transactions.Add(transaction);
                }
    
                return transactions;
            }
          public List<Transaction> GetAll(Client client) {
                List<Transaction> transactions = new List<Transaction>();
                foreach (var transaction in Transactions) {
                    if(transaction.Client.PersoniId.Equals(client.PersoniId))
                        transactions.Add(transaction);
                }
    
                return transactions;
            }
          
       
    }
}
