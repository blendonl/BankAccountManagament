using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class WithDraw : ITransaction {
        
        public string TransactionId { get;  }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Provision { get; set; }
        
        public DateTime Date { get;  }
        public bool TransactionStatus { get; set; }

        public static int count;

        public WithDraw() {
            TransactionId = "W" + count++;
            Date = DateTime.Now;
        }
        
        public bool MakeTransaction() {
            if (Account.Active) {
                if ((Amount + Provision) > Account.Balance) {
                    Account.Balance -= (Amount + Provision);
                    return TransactionStatus = true;
                }
            }

            return false;
        }

        public override string ToString() {
            return  $"TransactionId: {TransactionId} " + 
                    $"ClinetId: {Account.Client.PersoniId} " + 
                    $"AccountNumber: {Account.AccountNumber} " + 
                    $"TransactionType: {GetType().Name} " +
                    $"Amount: {Amount}"; 
        }
    }
}