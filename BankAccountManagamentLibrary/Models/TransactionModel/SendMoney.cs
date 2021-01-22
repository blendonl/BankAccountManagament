using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class SendMoney : ITransaction {
        
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public Account Account1 { get; set; }
        public decimal Provision { get; set; }
        public DateTime Date { get; set; }

        public bool TransactionStatus { get; set; }

        public bool MakeTransaction() {
            if (Account.Active && Account.Balance >= Amount && Account1.Active) {
                Account.Balance -= Amount;
                Account1.Balance += Amount;
                return TransactionStatus = true;
            }

            return false;
        }
        
        public override string ToString() { 
            return 
                $"ClinetId: {Account.Client.PersoniId} " + 
                $"AccountNumber: {Account.AccountNumber} " + 
                $"{(Account.Client != null ? ("ClientId1: " + Account.Client.PersoniId) : "")} " + 
                $"{(Account1 != null ? "AccountNumber1" + Account1.AccountNumber : "")} " + 
                $"TransactionType: {GetType().Name} " +
                $"Amount: {Amount}";
                
            }

    }
}