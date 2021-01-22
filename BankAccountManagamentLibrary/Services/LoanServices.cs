
namespace BankAccountManagamentLibrary.Services {
    // public class LoanServices : IService<Loan> {
    //     public List<Loan> Items { get; }
    //
    //     public LoanServices() {
    //         Items = new List<Loan>();
    //     }
    //
    //
    //
    //     public bool Add(Loan loan) {
    //         Items.Add(loan);
    //         BankServices.UpdateBalance(loan.Amount, TransactionType.Loan);
    //         return false;
    //
    //     }
    //
    //     public void MonthlyFee(string loanId) {
    //         
    //       
    //     }
    //
    //     public bool Remove(string loanId) {
    //         int index =Items.FindIndex(loan => loan.LoanId == loanId);
    //
    //         if (index != -1) {
    //             return Items.Remove(Items[index]);
    //             return true;
    //         }
    //         return false;
    //     }
    //
    //     public Loan Get(string loanId) {
    //         int index = Items.FindIndex(loan => loan.LoanId == loanId);
    //
    //         if (index != -1) {
    //             return Items[index];
    //         }
    //         
    //         return null;
    //     }
    //     public Loan GetFromAccount(long accountNumber) {
    //         int index =Items.FindIndex(loan => loan.Account.AccountNumber== accountNumber);
    //
    //         if (index != -1) {
    //             return Items[index];
    //         }
    //         
    //         return null;
    //     }
    //
    //     public bool Update(long loanId, decimal amount) {
    //         return false;
    //     }
    //     
    //     public List<Loan> GetAll() {
    //         List<Loan> loans =new List<Loan>();
    //         
    //         foreach (var loan in Items) {
    //               loans.Add(loan); 
    //         }
    //     
    //         return loans;
    //                              
    //     }  
    //     public List<Loan> GetAll(Account account) {
    //         List<Loan> loans =new List<Loan>();
    //
    //         foreach (var loan in Items) {
    //             if (account.AccountNumber == loan.Account.AccountNumber) {
    //                 loans.Add(loan);
    //             }
    //         }
    //
    //         return loans;
    //                  
    //     }
        
         // public List<Loan> GetAll(Client client) {
         //    List<Loan> loans =new List<Loan>();
         //    
         //    foreach (var loan in Items) {
         //        if(client.PersoniId.Equals(loan.Client.PersoniId))
         //          loans.Add(loan); 
         //    }
         //
         //    return loans;
         //                                 
         // } 
    // }
}
