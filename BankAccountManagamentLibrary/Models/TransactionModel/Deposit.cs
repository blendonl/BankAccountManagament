using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class Deposit : ITransaction {
        
        public string TransactionId { get;  }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Provision { get; set; }
        public DateTime Date { get;  }
        public bool TransactionStatus { get; set; }
        private static int count;

        public Deposit() {
            TransactionId = "D" + count++;
            Date = DateTime.Now;
        }
       
        public bool MakeTransaction() {
            if (Account.Active) { 
                Account.Balance += (Amount - Provision);
                return TransactionStatus = true;
            }
            return false;
        }


        public override string ToString() {
            return   
                $"TransactionId: {TransactionId} " + 
                $"ClinetId: {Account.Client.PersoniId} " + 
                $"AccountNumber: {Account.AccountNumber} " + 
                $"TransactionType: {GetType().Name} " +
                $"Amount: {Amount}"; 
        }
    }
}