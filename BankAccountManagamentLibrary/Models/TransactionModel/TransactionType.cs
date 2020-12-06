namespace BankAccountManagamentLibrary.Models.TransactionModel {

    /// <summary>
    /// Transaction typse
    /// for now are only two Deposit and Withdraw
    /// </summary>
   public enum TransactionType {
        Deposit,
        Withdraw,
        Send,
        Loan,
    }
}
