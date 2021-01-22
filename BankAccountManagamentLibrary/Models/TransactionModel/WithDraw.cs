using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class WithDraw : ITransaction {
        
        public int TransactionId { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Provision { get; set; }
        
        public DateTime Date { get; set; }
        public bool TransactionStatus { get; set; }
        
        public bool MakeTransaction() {
            if (Account.Active) {
                if ((Amount + Provision) > Account.Balance) ;
                Account.Balance -= (Amount + Provision);
                return TransactionStatus = true;
            }

            return false;
        }
    }
}