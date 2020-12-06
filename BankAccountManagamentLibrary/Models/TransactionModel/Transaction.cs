namespace BankAccountManagamentLibrary.Models.TransactionModel {

    public class Transaction {
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public long AccountNumber { get; set; }
        public string ClientId { get; set; }
        
        public long AccountNumber1 { get; set; }
        
        public string ClientId1 { get; set; }

        public override string ToString() {
            return $"ClinetId: {ClientId} AccountNumber: {AccountNumber} {(ClientId1.Length > 0 ? "ClientId1: " + (ClientId1.ToString() ): "")} {(AccountNumber1.ToString().Length > 0 ? "AccountNumber1" + AccountNumber1.ToString() : "")} transactionType: {TransactionType.ToString()} amount: {Amount}";
            
        }
    }
}
