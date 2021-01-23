using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankAccountManagamentLibrary.Services;

namespace BankaccountManagamentLibrary.Services {
    
    public class TransactionServices : IService<ITransaction> {
        public List<ITransaction> Items { get;  }
        
        public TransactionServices() {
            Items = new List<ITransaction>();
        }


        public bool Add(ITransaction transaction) {
            if(transaction.TransactionStatus) {
                 BankServices.UpdateBalance(transaction);
                 Items.Add(transaction);
                 return true;
            }
            return false;
        }
        
        public List<ITransaction> GetAll() {
            List<ITransaction> transactions = new List<ITransaction>();
            foreach (var transaction in Items) {
                transactions.Add(transaction);
            }

            return transactions;
        }
        public List<ITransaction> GetAll(Account account) {
            List<ITransaction> transactions = new List<ITransaction>();
            foreach (var transaction in Items) {
                if(transaction.Account.AccountNumber == account.AccountNumber)
                    transactions.Add(transaction);
            }

            return transactions;
        }
        public List<ITransaction> GetAll(Client client) { 
            List<ITransaction> transactions = new List<ITransaction>(); 
            foreach (var transaction in Items) { 
                if(transaction.Account.Client.PersoniId.Equals(client.PersoniId)) 
                    transactions.Add(transaction);
                
            }
    
            return transactions;
        }
        
        public decimal ProvisionPercentage(decimal provision) { 
           return provision / 100 * 100;
        }
    }
}
