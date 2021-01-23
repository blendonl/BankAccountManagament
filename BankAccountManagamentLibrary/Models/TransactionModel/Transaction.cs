using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {

    public interface ITransaction {
        public string TransactionId { get;  }
        public decimal Amount { get; set; }
        public Account Account{ get; set; }
        public decimal Provision { get; set; }
        public DateTime Date { get;  }
        public bool TransactionStatus { get; set; }
        
        bool MakeTransaction();

    }
}
