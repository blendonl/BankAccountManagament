using System.Collections.Generic;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.TransactionModel;

namespace BankAccountManagamentLibrary.Services {
    public class LoanServices {
        private List<Loan> Loans;

        public LoanServices() {
            Loans = new List<Loan>();
        }
        

        public bool Add(Loan loan) {
            Loans.Add(loan); 
            BankServices.UpdateBalance(loan.Amount, TransactionType.Loan);
            loan.Account.Deposit(loan.Amount, 0);
            return true;
        
            return false;

        }

        public void MonthlyFee(string loanId) {
            
            Loan loan = Get(loanId);
            if (loan.Paid < loan.Amount) {
                if (loan.IsMonth()) {
                    if (!loan.Account.WithDraw(loan.MonthlyFee(), loan.InteresRate)) {
                        loan.InteresRate++;
                    } 
                }
            }
        }

        public bool Remove(string loanId) {
            int index =Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Loans.Remove(Loans[index]);
                return true;
            }
            return false;
        }

        public Loan Get(string loanId) {
            int index = Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Loans[index];
            }
            
            return null;
        }
        public Loan GetFromAccount(long accountNumber) {
            int index =Loans.FindIndex(loan => loan.Account.AccountNumber== accountNumber);

            if (index != -1) {
                return Loans[index];
            }
            
            return null;
        }

        public bool Update(long loanId, decimal amount) {
            return false;
        }
        
        public List<Loan> GetAll() {
            List<Loan> loans =new List<Loan>();
            
            foreach (var loan in Loans) {
                  loans.Add(loan); 
            }
        
            return loans;
                                 
        }  
        public List<Loan> GetAll(Account account) {
            List<Loan> loans =new List<Loan>();
  
            foreach (var loan in Loans) {
                if (account.AccountNumber == loan.Account.AccountNumber) {
                    loans.Add(loan);
                }
            }

            return loans;
                     
        }
        
         public List<Loan> GetAll(Client client) {
            List<Loan> loans =new List<Loan>();
            
            foreach (var loan in Loans) {
                if(client.PersoniId.Equals(loan.Client.PersoniId))
                  loans.Add(loan); 
            }
        
            return loans;
                                         
         } 
    }
}
