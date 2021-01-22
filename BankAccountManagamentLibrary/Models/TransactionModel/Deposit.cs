using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class Deposit : ITransaction {
        
        public int TransactionId { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Provision { get; set; }
        public DateTime Date { get; set; }
        public bool TransactionStatus { get; set; }
       
        public bool MakeTransaction() {
            if (Account.Active) { 
                Account.Balance += (Amount - Provision);
                return TransactionStatus = true;
            }
            return false;
        }


        public override string ToString() {
            return   
                $"ClinetId: {Account.Client.PersoniId} " + 
                $"AccountNumber: {Account.AccountNumber} " + 
                $"TransactionType: {GetType().Name} " +
                $"Amount: {Amount}"; 
        }
    }
}