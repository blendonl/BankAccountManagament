using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {

    public class Transaction {
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public Account Account{ get; set; }
        public Account Account1 { get; set; }
        public Client Client { get; set; }
        
        public Client Client1 { get; set; }
        
        public decimal Provision { get; set; }

        public override string ToString() {
            return 
                $"ClinetId: {Client.ClientId} " +
                $"AccountNumber: {Account.AccountNumber} " +
                $"{(Client1 != null ? ("ClientId1: " + Client1.ClientId) : "")} " +
                $"{(Account1 != null ? "AccountNumber1" + Account1.AccountNumber.ToString() : "")} " +
                $"transactionType: {TransactionType.ToString()} amount: {Amount}";
            
        }
    }
}
